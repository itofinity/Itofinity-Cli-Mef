using Itofinity.Cli.Mef.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.CommandLineUtils;
using System.Threading.Tasks;
using System.Linq;
using Itofinity.Cli.Mef.Utils;

namespace Itofinity.Cli.Mef.Authentication
{
    public class CliAuthenticationManager : AbstractCliAuthenticationManager
    {
        public static void SetAuthenticationOptions(CommandLineApplication config)
        {
            config.Option("-t", "API Token", CommandOptionType.SingleValue);
            config.Option("-u", "Username", CommandOptionType.SingleValue);
            config.Option("-p", "Password", CommandOptionType.SingleValue);
        }

        public override Tuple<string, string> GetAuthenticationHeader(CommandLineApplication config)
        {
            var username = CommandLineHelper.GetOptionValue(config, "-u");
            var password = CommandLineHelper.GetOptionValue(config, "-p");
            var token = CommandLineHelper.GetOptionValue(config, "-t");

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                string _auth = string.Format("{0}:{1}", username, password);
                string _enc = Convert.ToBase64String(Encoding.ASCII.GetBytes(_auth));
                return new Tuple<string, string>("Basic", _enc);
            }

            if (!string.IsNullOrWhiteSpace(token))
            {
                return new Tuple<string, string>("Bearer", token);
            }

            return null;

        }
    }
}
