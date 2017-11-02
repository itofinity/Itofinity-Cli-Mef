using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.CommandLineUtils;
using Itofinity.Cli.Mef.Utils;

namespace Itofinity.Cli.Mef.Output
{
    public static class CSharpStringFormatter
    {
        public static string ReplaceMacro<T>(string format, T obj)
        {
            if(obj == null)
            {
                return null;
            }
            var usedProperties = new List<string>();
            var formatted = Regex.Replace(format, @"{(?<exp>[^}]+)}", match => {
                var p = Expression.Parameter(typeof(T), typeof(T).Name);
                try
                {
                    var name = match.Groups["exp"].Value;
                    var e = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, null, name);
                    var val = (e.Compile().DynamicInvoke(obj) ?? "").ToString();
                    if(!string.IsNullOrWhiteSpace(val))
                    {
                        usedProperties.Add(name);
                    }
                    return val;
                }
                catch(Exception ex)
                {
                    // do anything?
                    int i = 0;
                }
                return "{Error:" + match.Groups["exp"].Value + "}";
            });

            if (formatted.Contains("{Error:*}"))
            {
                var remainingBuffer = new StringBuilder();
                var properties = obj.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var name = property.Name;
                    if (usedProperties.Contains($"{typeof(T).Name.ToLower()}.{name}"))
                    {
                        continue;
                    }
                    var val = property.GetValue(obj);
                    if(remainingBuffer.Length > 0)
                    {
                        remainingBuffer.Append($",");
                    }
                    remainingBuffer.Append($"{name}=[{val}]");
                }

                formatted = formatted.Replace("{Error:*}", $"[{remainingBuffer}]");
            }

            return formatted;
        }

        public static void SetFormatOptions(CommandLineApplication config)
        {
            config.Option("-f", "format", CommandOptionType.SingleValue);
        }

        public static string GetOutputFormat(CommandLineApplication config, string defaultFormat)
        {
            var overrideFormat = CommandLineHelper.GetOptionValue(config, "-f");
            if(!string.IsNullOrWhiteSpace(overrideFormat))
            {
                return overrideFormat;
            }

            return defaultFormat;
        }
    }
}
