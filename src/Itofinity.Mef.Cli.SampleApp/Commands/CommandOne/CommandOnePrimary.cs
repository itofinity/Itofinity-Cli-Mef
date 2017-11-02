using Itofinity.Cli.Mef;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itofinity.Mef.Cli.SampleApp.Commands.CommandOne
{
    public class CommandOnePrimary : PrimaryCommandDefinition
    {
        public CommandOnePrimary(ISecondaryCommandDefinition secondaryCommandDefinition) : base("primary", new List<ISecondaryCommandDefinition>() { secondaryCommandDefinition })
        {
        }
    }
}
