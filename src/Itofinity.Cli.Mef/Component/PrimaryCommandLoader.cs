using Itofinity.Cli.Mef.Authentication;
using Itofinity.Cli.Mef.Configuration;
using System;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Reflection;

namespace Itofinity.Cli.Mef.Component
{
    public class PrimaryCommandLoader : ComponentLoader
    {
        public static IEnumerable<ICommandDefinition> Load(Assembly host, string extPath, string extPattern)
        {
            ConventionBuilder conventions = PrimaryCommandConventions();

            return Load(host, extPath, extPattern, conventions);
        }

        private static ConventionBuilder PrimaryCommandConventions()
        {
            var conventions = new ConventionBuilder();
            conventions
                .ForTypesDerivedFrom<IPrimaryCommandDefinition>()
                .Export<IPrimaryCommandDefinition>()
                .Shared();
            conventions
                .ForTypesDerivedFrom<ISecondaryCommandDefinition>()
                .Export<ISecondaryCommandDefinition>()
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
            return conventions;
        }

    }
}
