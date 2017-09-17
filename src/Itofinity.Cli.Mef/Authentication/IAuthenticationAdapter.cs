using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.CommandLineUtils;

namespace Itofinity.Cli.Mef.Authentication
{
    public interface IAuthenticationAdapter
    {
        Func<Task<Tuple<string, string>>> GetAuthenticationHandler(CommandLineApplication config);
    }
}
