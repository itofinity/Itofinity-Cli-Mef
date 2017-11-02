using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Itofinity.Cli.Mef
{
    public class Cli
    {
        public static void Run(string[] args, Assembly host, string extPath = "", string extPattern = "*", bool pauseOnExit = false)
        {
            var app = new Microsoft.Extensions.CommandLineUtils.CommandLineApplication();

            var primaryCommands = PrimaryCommandLoader.Load(host, extPath, extPattern);

            primaryCommands.ToList().ForEach(pc =>
            {
                var command = app.Command(pc.Name, pc.Config);
                pc.SubCommandDefinitions.ToList().ForEach(sc => command.Command(sc.Name, sc.Config));
            });

            //give people help with --help

            app.HelpOption("-? | -h | --help");

            if(!args.Any())
            {
                args = new string[] { "--help" };
            }
            var result = app.Execute(args);

            if (pauseOnExit)
            {
                Console.WriteLine("Hit Return to exit.");
                Console.ReadLine();
            }

            Environment.Exit(result);
        }
    }
}
