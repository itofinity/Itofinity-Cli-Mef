using System;
using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Itofinity.Cli.Mef
{
    /// <summary>
    ///  see https://weblogs.asp.net/ricardoperes/using-mef-in-net-core
    /// </summary>
    public static class ContainerConfigurationExtensions
    {
        public static ContainerConfiguration WithAssembliesInPath(this ContainerConfiguration configuration, string path, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return WithAssembliesInPath(configuration, path, "*", null, searchOption);
        }

        public static ContainerConfiguration WithAssembliesInPath(this ContainerConfiguration configuration, string path, string searchPattern, AttributedModelProvider conventions, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return configuration;
            }

            var assemblies = Directory
                .GetFiles(path,searchPattern, searchOption)
                .Select(AssemblyLoadContext.GetAssemblyName)
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyName)
                .ToList();

            configuration = configuration.WithAssemblies(assemblies, conventions);

            return configuration;
        }
    }
}
