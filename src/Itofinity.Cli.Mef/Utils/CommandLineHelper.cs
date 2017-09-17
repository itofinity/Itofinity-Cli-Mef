﻿using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace Itofinity.Cli.Mef.Utils
{
    public static class CommandLineHelper
    {
        public static string GetOptionValue(CommandLineApplication config, string template)
        {
            var option = config.Options.Where(o => o.Template.Equals(template, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (option == null)
            {
                return null;
            }

            return option.Value();
        }
    }
}
