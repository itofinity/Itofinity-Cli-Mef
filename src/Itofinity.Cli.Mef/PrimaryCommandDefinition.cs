using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;

namespace Itofinity.Cli.Mef
{
    public class PrimaryCommandDefinition : CommandDefinition, IPrimaryCommandDefinition
    {
        public PrimaryCommandDefinition(string name, IEnumerable<ICommandDefinition> subCommandDefinitions) : base(name, GetConfig(), subCommandDefinitions)
        {
        }

        private static Action<CommandLineApplication> GetConfig()
        {
            return config =>
            {
                config.OnExecute(() =>
                {
                    config.ShowHelp(); //show help for catapult

                    return 1; //return error since we didn't do anything
                });

                config.HelpOption("-? | -h | --help"); //show help on --help
            };
        }
    }
}
