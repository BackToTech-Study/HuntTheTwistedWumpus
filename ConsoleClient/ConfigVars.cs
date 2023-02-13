using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ConsoleClient
{
    public class ConfigVars
    {
        public class SignalRConfig
        {
            public string BaseUrl { get; } 

            public SignalRConfig()
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                BaseUrl = configuration.GetSection("SignalR")["BaseUrl"];
            }
        }



    }
}
