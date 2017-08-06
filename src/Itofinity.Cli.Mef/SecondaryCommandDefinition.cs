using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;

namespace Itofinity.Cli.Mef
{
    public class SecondaryCommandDefinition : CommandDefinition, ISecondaryCommandDefinition
    {
        public SecondaryCommandDefinition(string name, Action<CommandLineApplication> config) : base(name, config, new List<ICommandDefinition>())
        {
        }
    }
}
