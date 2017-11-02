using Itofinity.Cli.Mef;
using Itofinity.Cli.Mef.Output;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Itofinity.Mef.Cli.SampleApp.Commands.CommandOne
{
    public class CommandOneSecondary : SecondaryCommandDefinition
    {
        public CommandOneSecondary() : base("secondary", GetConfig())
        {
        }

        private static Action<CommandLineApplication> GetConfig()
        {
            return config =>
            {
                config.HelpOption("-? | -h | --help");

                // arguments
                var argOne = config.Argument("argOne", "Arg One", false);
                var argTwo = config.Argument("argTwo", "Arg Two", false);

                // options
                var optionCase = config.Option("-c", "case", CommandOptionType.SingleValue);

                CSharpStringFormatter.SetFormatOptions(config);

                config.Description = "Sample command, writes back the arguments, optionally in upper or lower case";

                config.OnExecute(() =>
                {
                    var one = argOne.Value;
                    var two = argTwo.Value;
                    var casse = optionCase.Value();

                    if("upper".Equals(casse, StringComparison.InvariantCultureIgnoreCase))
                    {
                        one = one != null ? one.ToUpper() : "UNDEFINED";
                        two = two != null ? two.ToUpper() : "UNDEFINED";
                    }
                    else
                    {
                        one = one != null ? one.ToLower() : "undefined";
                        two = two != null ? two.ToLower() : "undefined";
                    }

                    Console.WriteLine($"argOne=[{one}] argTwo=[{two}]");
                    return 0;
                });
            };
        }
    }
}
