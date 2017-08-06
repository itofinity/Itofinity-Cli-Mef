using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itofinity.Cli.Mef
{
    public class CommandDefinition : ICommandDefinition
    {
        public CommandDefinition(string name, Action<CommandLineApplication> config, IEnumerable<ICommandDefinition> subCommandDefinitions)
        {
            Name = name;
            Config = config;
            SubCommandDefinitions = subCommandDefinitions;
        }
        public CommandDefinition(string name, Action<CommandLineApplication> config) : this(name, config, new List<ICommandDefinition>())
        { }

        public string Name { get; }
        public Action<CommandLineApplication> Config { get; }
        public IEnumerable<ICommandDefinition> SubCommandDefinitions { get; }
    }
}
