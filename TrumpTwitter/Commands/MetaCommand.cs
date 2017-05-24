using System;
using System.Collections.Generic;
using System.Linq;
using TrumpTwitter.Attributes;
using TrumpTwitter.Extensions;
using Tweetinvi.Models;

namespace TrumpTwitter.Commands
{
    public class MetaCommand
    {
        const string metaHelp = "View extracted metadata for trumps twitter activity";

        const string expandedMetaHelp = metaHelp + "\n\n" +
            "Shows the sources of his tweets. More to come.";

        [Command(QuickHelp = metaHelp, ExpandedHelp = expandedMetaHelp)]
        private static void Meta(IEnumerable<ITweet> tweets, string param)
        {
            var sources = tweets
                .DistinctBy(t => t.Source)
                .Select(t => (string)t.Source);

            Dictionary<string, int> sourceCount = new Dictionary<string, int>();
            foreach (var source in sources)
            {
                sourceCount.Add(source, tweets.Count(t => t.Source == source));
            }

            Console.WriteLine("Sources:");
            foreach (var source in sourceCount)
            {
                Console.WriteLine($"\t'{Tools.ParseSource(source.Key)}' tweeted from {source.Value} times");
            }
        }
    }
}
