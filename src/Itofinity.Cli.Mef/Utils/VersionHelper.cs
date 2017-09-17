using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Itofinity.Cli.Mef.Utils
{
    public static class VersionHelper
    {
        public static Version GetVersion(Assembly assembly)
        {
            return assembly.GetName().Version;
        }

        public static string GetVersionString(Assembly assembly)
        {
            return $"{assembly.GetName().Name} v{assembly.GetName().Version}";
        }
    }
}
