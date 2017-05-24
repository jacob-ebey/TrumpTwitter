using System;
using System.Collections.Generic;
using System.Linq;
using TrumpTwitter.Attributes;

namespace TrumpTwitter.Commands
{
    public class HelpCommand
    {
        static internal IEnumerable<CommandAttribute> Commands { get; set; }

        const string quickHelp = "Show help info";
        const string description =
            "To view more detailed info of the following commands you can used help like so:\n" +
            "\thelp <COMMAND_NAME>";
        const string expandedHelp = quickHelp + "\n\n" + description;

        [Command(QuickHelp = quickHelp, ExpandedHelp = expandedHelp)]
        public static void Help(string commandName)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                Console.WriteLine(expandedHelp);

                Console.WriteLine();
                Console.WriteLine("Commands:");
                foreach (var command in Commands.OrderBy(c => c.Name))
                {
                    Console.WriteLine($"\t{command.Name}{(command.QuickHelp != null ? $" | {command.QuickHelp}" : null)}");
                }
                Console.WriteLine("\tExit | Closes the application");
            }
            else
            {
                var command = Commands.FirstOrDefault(c => c.Name.ToLower() == commandName);
                if (command != null)
                {
                    Console.WriteLine(command.ExpandedHelp ?? command.QuickHelp ?? $"No help avaliable for {commandName}");
                }
                else
                {
                    Console.WriteLine($"Couldn't find command '{commandName}'");
                }
            }
        }
    }
}
