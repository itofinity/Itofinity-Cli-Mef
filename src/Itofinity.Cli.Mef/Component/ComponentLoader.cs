using System;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace Itofinity.Cli.Mef.Component
{
    public class ComponentLoader
    {
        public static IEnumerable<ICommandDefinition> Load(Assembly host, string extPath, string extPattern, ConventionBuilder conventions)
        {
            var assemblies = new[] { host };

            var configuration = new ContainerConfiguration()
                .WithAssembliesInPath(extPath, extPattern, conventions, System.IO.SearchOption.AllDirectories)
                .WithAssemblies(assemblies, conventions);

            using (var container = configuration.CreateContainer())
            {
                var commands = container.GetExports<IPrimaryCommandDefinition>();
                return commands;
            }
        }
    }
}
