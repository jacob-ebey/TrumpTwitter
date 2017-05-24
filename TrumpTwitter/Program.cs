using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TrumpTwitter.Attributes;
using TrumpTwitter.Commands;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TrumpTwitter
{
    class Program
    {
        private static IEnumerable<ITweet> tweets;

        internal static string StorageDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TrumpTweets");
        internal static string TweetsFile = Path.Combine(StorageDir, "tweets.json");
        internal static string SearchFile = Path.Combine(StorageDir, "search.json");

        static void Main(string[] args)
        {
            bool keepRunning = true;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e)
            {
                keepRunning = false;
                e.Cancel = true;
            };

            Console.WriteLine("Initializing...");

            Auth.SetUserCredentials(
                "<CONSUMER_KEY>",
                "<CONSUMER_SECRET>",
                "<USER_ACCESS_TOKEN>",
                "<USER_ACCESS_SECRET>");

            var commands = typeof(Program)
                .Assembly
                .DefinedTypes
                .Where(t => t.IsClass)
                .SelectMany(t => t.DeclaredMethods)
                .Where(m => m.IsStatic && m.GetCustomAttributes(typeof(CommandAttribute), false).Any())
                .ToDictionary(
                    m => GetMethodName(m).ToLower(),
                    m =>
                    {
                        var attribute = m.GetCustomAttribute<CommandAttribute>();
                        attribute.Name = GetMethodName(m);
                        return new
                        {
                            Method = m,
                            Attribute = attribute
                        };
                    });

            HelpCommand.Commands = commands.Select(c => c.Value.Attribute);

            LoadTweets();

            while (keepRunning)
            {
                Console.Write("Command (help): ");
                var commandSplit = Console.ReadLine()?.Trim().ToLower().Split(new[] { ' ' }, 2);
                
                if (!string.IsNullOrWhiteSpace(commandSplit?[0]) && commands.ContainsKey(commandSplit[0]))
                {
                    object[] param = null;
                    if (commands[commandSplit[0]].Method.GetParameters().Length == 1)
                    {
                        param = new object[] { commandSplit.Length == 2 ? commandSplit[1] : null };
                    }
                    else if (commands[commandSplit[0]].Method.GetParameters().Length == 2)
                    {
                        param = new object[] { tweets, commandSplit.Length == 2 ? commandSplit[1] : null };
                    }
                    Console.WriteLine();
                    commands[commandSplit[0]].Method.Invoke(null, param);
                }
                else if (commandSplit?[0] == "exit")
                {
                    keepRunning = false;
                    Console.WriteLine("Exiting...");
                }
                else if (commandSplit != null)
                {
                    Console.WriteLine();
                    commands["help"].Method.Invoke(null, new object[] { null });
                }

                Console.WriteLine();

                Task.Delay(10);
            }
        }

        static string GetMethodName(MethodInfo method)
        {
            return method.GetCustomAttribute<CommandAttribute>().Name ?? method.Name;
        }

        private static void LoadTweets()
        {
            Console.Write("Loading tweets for Donald Trump...");
            Directory.CreateDirectory(StorageDir);
            string json = "[]";
            try
            {
                json = File.ReadAllText(TweetsFile);
            }
            catch { }
            tweets = JsonConvert.DeserializeObject<IEnumerable<TweetTemplate>>(json);
            var newTweets = GetAllTweetsForUser(oldestId: tweets.FirstOrDefault()?.Id ?? -1);
            tweets = newTweets.Concat(tweets);
            File.WriteAllText(TweetsFile, JsonConvert.SerializeObject(tweets));
            Console.WriteLine();
        }

        static IEnumerable<ITweet> GetAllTweetsForUser(long userId = 25073877, long oldestId = -1)
        {
            RateLimit.RateLimitTrackerMode = RateLimitTrackerMode.TrackAndAwait;

            RateLimit.QueryAwaitingForRateLimit += (sender, args) =>
            {
                Console.WriteLine($"Awaiting for rate limits...");
            };

            var lastTweets = Timeline.GetUserTimeline(userId, 200).ToArray();

            var allTweets = new List<ITweet>(lastTweets.Where(t => !t.IsRetweet));
            var beforeLast = allTweets;

            while (lastTweets.Length > 0 && allTweets.Count <= 3200)
            {
                var idOfOldestTweet = lastTweets.Select(x => x.Id).Min();
                Console.Write(".");

                if (oldestId != -1 && idOfOldestTweet < oldestId)
                {
                    return allTweets.Where(t => t.Id > oldestId);
                }

                var numberOfTweetsToRetrieve = allTweets.Count > 3000 ? 3200 - allTweets.Count : 200;
                var timelineRequestParameters = new UserTimelineParameters
                {
                    // MaxId ensures that we only get tweets that have been posted 
                    // BEFORE the oldest tweet we received
                    MaxId = idOfOldestTweet - 1,
                    MaximumNumberOfTweetsToRetrieve = numberOfTweetsToRetrieve,
                    ExcludeReplies = true,
                    IncludeContributorDetails = false,
                    IncludeEntities = false,
                    IncludeRTS = false,
                };

                lastTweets = Timeline.GetUserTimeline(userId, timelineRequestParameters).ToArray();
                allTweets.AddRange(lastTweets.Where(t => !t.IsRetweet));
            }

            return allTweets;
        }
    }
}
