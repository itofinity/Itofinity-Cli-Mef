using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;

namespace Itofinity.Cli.Mef.Command
{
    public class HelpPrimaryCommand : PrimaryCommandDefinition
    {
        public HelpPrimaryCommand() : base(GetName(), GetSubCommands(GetName()))
        {
        }

        private static IEnumerable<ICommandDefinition> GetSubCommands(string name)
        {
            return new List<ICommandDefinition>()
                {
                    new HelpSecondaryCommand(GetName())
                };
        }

        private static string GetName()
        {
            return "help";
        }
    }
}
