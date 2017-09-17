using Itofinity.Cli.Mef.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace Itofinity.Cli.Mef
{
    public class AppConfiguration : IAppConfiguration
    {
        private FileVersionInfo _version;
        private string _name;

        public FileVersionInfo Version
        {
            get
            {
                if (_version == null)
                {
                    _version = FileVersionInfo.GetVersionInfo(Assembly.GetCallingAssembly().Location);
                }

                return _version;
            }
        }

        public string Name
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_name))
                {
                    _name = Assembly.GetEntryAssembly().GetName().Name;
                }

                return _name;
            }
        }
    }
}