using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;
using System.Reflection;
using Itofinity.Cli.Mef.Utils;

namespace Itofinity.Cli.Mef.Command
{
    public class VersionPrimaryCommand : CommandDefinition, IPrimaryCommandDefinition
    {
        public VersionPrimaryCommand() : base(GetName(), GetConfig(), GetSubCommands(GetName()))
        {
        }

        private static Action<CommandLineApplication> GetConfig()
        {
            return config =>
            {

                config.Description = "application version";

                config.OnExecute(() =>
                {
                    Console.WriteLine(VersionHelper.GetVersionString(Assembly.GetEntryAssembly()));

                    return 0;
                });
            };
        }

        private static IEnumerable<ICommandDefinition> GetSubCommands(string name)
        {
            return new List<ICommandDefinition>();
        }

        private static string GetName()
        {
            return "version";
        }
    }
}
