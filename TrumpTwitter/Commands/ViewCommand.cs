using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TrumpTwitter.Attributes;
using TrumpTwitter.Extensions;
using Tweetinvi.Models;

namespace TrumpTwitter.Commands
{
    public class ViewCommand
    {
        const string viewHelp = "View a specific tweet + or - an optional count";

        const string expandedViewHelp = viewHelp + "\n\n" +
            "To view a specific tweet, do the following:\n" +
            "\tview <TWEET_ID> <OPTIONAL_COUNT>\n" +
            "Params:\n\tTWEET_ID: The id of the tweet\n\tOPTIONAL_COUT: Optional count where a positive is the next n tweets and a negative is the previous n tweets";

        [Command(QuickHelp = viewHelp, ExpandedHelp = expandedViewHelp)]
        private static void View(IEnumerable<ITweet> tweets, string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                Console.WriteLine("No id provided");
                return;
            }

            string[] paramSplit = param.Split(new[] { ' ' }, 2);

            long id = -1;
            if (long.TryParse(paramSplit[0], out id))
            {
                var tweet = tweets.FirstOrDefault(t => t.Id == id);


                IEnumerable<ITweet> viewTweets = tweets.OrderBy(t => t.Id);
                int index = viewTweets.IndexOf(tweet);

                int skip = index;
                int take = 1;

                int nextCount = -1;
                if (int.TryParse(paramSplit.Length == 2 ? paramSplit[1] : "", out nextCount))
                {
                    skip = nextCount >= 0 ? skip : skip + nextCount;
                    take += Math.Abs(nextCount);

                }

                viewTweets = viewTweets
                    .Skip(skip)
                    .Take(take);

                Console.WriteLine(JsonConvert.SerializeObject(viewTweets));
            }
            else
            {
                Console.WriteLine("Couldn't parse id :(");
            }
        }
    }
}
