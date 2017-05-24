using System;

namespace TrumpTwitter.Attributes
{
    public class CommandAttribute : Attribute
    {
        public string Name { get; set; }

        public string QuickHelp { get; set; }

        public string ExpandedHelp { get; set; }

        public bool RunOnStartup { get; set; }
    }
}
