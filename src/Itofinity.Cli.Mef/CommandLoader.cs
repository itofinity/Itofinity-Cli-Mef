using Itofinity.Cli.Mef.Authentication;
using Itofinity.Cli.Mef.Configuration;
using System;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Reflection;

namespace Itofinity.Cli.Mef
{
    public class PrimaryCommandLoader
    {
        public static IEnumerable<IPrimaryCommandDefinition> Load(Assembly host, string extPath)
        {
            var conventions = new ConventionBuilder();
            conventions
                .ForTypesDerivedFrom<IPrimaryCommandDefinition>()
                .Export<IPrimaryCommandDefinition>()
                .Shared();
            conventions
                .ForTypesDerivedFrom<IRestConfiguration>()
                .Export<IRestConfiguration>()
                .Shared();
            conventions
                .ForTypesDerivedFrom<IAppConfiguration>()
                .Export<IAppConfiguration>()
                .Shared();
            conventions
                .ForTypesDerivedFrom<IAuthenticationAdapter>()
                .Export<IAuthenticationAdapter>()
                .Shared();

            var assemblies = new[] { host, Assembly.GetAssembly(typeof(PrimaryCommandLoader))};

            var configuration = new ContainerConfiguration()
                .WithAssembliesInPath(extPath, conventions)
                .WithAssemblies(assemblies, conventions);

            using (var container = configuration.CreateContainer())
            {
                var commands = container.GetExports<IPrimaryCommandDefinition>();
                return commands;
            }
        }
    }
}
