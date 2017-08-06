using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Itofinity.Cli.Mef
{
    public class Cli
    {
        public static void Run(string[] args, Assembly host)
        {
            var app = new Microsoft.Extensions.CommandLineUtils.CommandLineApplication();

            var primaryCommands = PrimaryCommandLoader.Load(host, ".");

            primaryCommands.ToList().ForEach(pc =>
            {
                var command = app.Command(pc.Name, pc.Config);
                pc.SubCommandDefinitions.ToList().ForEach(sc => command.Command(sc.Name, sc.Config));
            });

            //give people help with --help

            app.HelpOption("-? | -h | --help");

            var result = app.Execute(args);

#if DEBUG
            Console.WriteLine("Hit Return to exit.");
            Console.ReadLine();
#endif
            Environment.Exit(result);
        }
    }
}
