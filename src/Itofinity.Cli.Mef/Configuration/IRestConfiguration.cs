using System;
using System.Collections.Generic;
using System.Text;

namespace Itofinity.Cli.Mef.Configuration
{
    public interface IRestConfiguration
    {
        string BaseApiUrl { get; }
        string UserAgent { get; }
    }
}
