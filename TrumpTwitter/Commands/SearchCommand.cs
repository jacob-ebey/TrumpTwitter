using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TrumpTwitter.Attributes;
using Tweetinvi.Models;

namespace TrumpTwitter.Commands
{
    public class SearchCommand
    {
        const string searchHelp = "Search Trump's tweets for keywords";

        const string expandedSearchHelp = searchHelp + "\n\n" +
            "You can search for multiple keywords by separating them with a | character. For example:\n" +
            "\tsearch russia|putin";

        [Command(QuickHelp = searchHelp, ExpandedHelp = expandedSearchHelp)]
        private static void Search(IEnumerable<ITweet> tweets, string query)
        {
            var searchStrings = query.Split('|');
            Func<string, bool> doCheck = (string text) =>
            {
                foreach (var searchString in searchStrings)
                {
                    if (text.ToLower().Contains(searchString.ToLower()))
                    {
                        return true;
                    }
                }
                return false;
            };
            var results = tweets
                .Where(t => doCheck(t.FullText));
                //.Select(t => new
                //{
                //    Id = t.Id,
                //    FullText = WebUtility.HtmlDecode(t.FullText),
                //    CreatedAt = t.CreatedAt,
                //    Source = Tools.ParseSource(t.Source),
                //    Url = t.Url
                //});

            Console.WriteLine();
            Console.WriteLine($"Found {results.Count()} tweets since {tweets.Last().CreatedAt.ToString("MMM d yyyy")} containing '{query.Replace("|", "' or '")}'.");
            Console.WriteLine();

            File.WriteAllText(Program.SearchFile, JsonConvert.SerializeObject(new
            {
                Count = results.Count(),
                Since = tweets.Last().CreatedAt,
                Results = results
            }));

            Console.WriteLine($"Opening {Program.SearchFile}");
            Process.Start(Program.SearchFile).WaitForInputIdle();
        }
    }
}
