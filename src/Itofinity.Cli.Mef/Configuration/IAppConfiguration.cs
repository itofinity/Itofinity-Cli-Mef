using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Itofinity.Cli.Mef.Configuration
{
    public interface IAppConfiguration
    {
        FileVersionInfo Version { get; }
        string Name { get; }
    }
}
