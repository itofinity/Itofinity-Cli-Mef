using Itofinity.Cli.Mef;
using Microsoft.Extensions.CommandLineUtils;
using System;

namespace Itofinity.Cli.Mef.Command
{
    internal class HelpSecondaryCommand : SecondaryCommandDefinition
    {
        public HelpSecondaryCommand(string primaryCommandName) : base(GetName(), GetConfig(primaryCommandName))
        {
        }

        private static Action<CommandLineApplication> GetConfig(string primaryCommandName)
        {
            return config =>
            {
                config.Description = "get help!";

                config.OnExecute(() =>
                {
                    config.ShowHelp(primaryCommandName);
                    return 1;
                });
            };
        }

        private static string GetName()
        {
            return "help";
        }
    }
}