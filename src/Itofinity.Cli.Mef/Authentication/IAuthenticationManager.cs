using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Itofinity.Cli.Mef.Authentication
{
    public interface IAuthenticationManager
    {
        Tuple<string, string> GetAuthenticationHeader(CommandLineApplication config);
    }
}
