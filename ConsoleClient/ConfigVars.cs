using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ConsoleClient
{
    public class ConfigVars
    {
        public IConfiguration configuration;
        public string BaseUrl { get { return configuration.GetSection("BaseUrl").Value; } }   

        public ConfigVars(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}
