using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;
using System.Linq;

namespace Itofinity.Cli.Mef.Authentication
{
    public abstract class AbstractCliAuthenticationManager : IAuthenticationManager
    {
        public abstract Tuple<string, string> GetAuthenticationHeader(CommandLineApplication config);
    }
}
