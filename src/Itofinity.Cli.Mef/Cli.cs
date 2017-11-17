using Itofinity.Cli.Mef.Command;
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

            var primaryCommands = new List<ICommandDefinition>();
            var loadedCommands = PrimaryCommandLoader.Load(host, extPath, extPattern);

            // add default commmands
            if(!loadedCommands.Any(pc => pc.Name.Equals("version", StringComparison.InvariantCultureIgnoreCase)))
            {
                primaryCommands.Add(new VersionPrimaryCommand());
            }

            primaryCommands.AddRange(loadedCommands);

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

            int result = 0;
            try
            {
                result = app.Execute(args);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = app.Execute(new string[] { "--help" });
            }

            if (pauseOnExit)
            {
                Console.WriteLine("Hit Return to exit.");
                Console.ReadLine();
            }

            Environment.Exit(result);
        }
    }
}
