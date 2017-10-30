using Itofinity.Cli.Mef.Authentication;
using Itofinity.Cli.Mef.Configuration;
using System;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Reflection;

namespace Itofinity.Cli.Mef
{
    public class ComponentLoader
    {
        public static IEnumerable<IPrimaryCommandDefinition> Load(Assembly host, string extPath, ConventionBuilder conventions)
        {
            var assemblies = new[] { host, Assembly.GetAssembly(typeof(ComponentLoader))};

            var configuration = new ContainerConfiguration()
                .WithAssembliesInPath(extPath, conventions, System.IO.SearchOption.AllDirectories)
                .WithAssemblies(assemblies, conventions);

            using (var container = configuration.CreateContainer())
            {
                var commands = container.GetExports<IPrimaryCommandDefinition>();
                return commands;
            }
        }
    }
}
