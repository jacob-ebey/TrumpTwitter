using System.Linq;

namespace TrumpTwitter.Commands
{
    class Tools
    {
        internal static string ParseSource(string source)
        {
            if (source?.Length <= 0)
            {
                return "Unknown";
            }

            var start = source.IndexOf('>');
            if (start >= 0)
            {
                var end = new string(source.Skip(start + 1).ToArray()).IndexOf('<');
                if (end > 0)
                {
                    return source.Substring(start + 1, end);
                }
            }

            return source;
        }
    }
}
