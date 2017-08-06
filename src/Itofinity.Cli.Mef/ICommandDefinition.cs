using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;

namespace Itofinity.Cli.Mef
{
    public interface ICommandDefinition
    {
        string Name { get; }
        Action<CommandLineApplication> Config { get; }
        IEnumerable<ICommandDefinition> SubCommandDefinitions { get; }
    }
}
