using Microsoft.Extensions.DependencyInjection;

namespace ConsoleClient.Connection
{
    public static class SignalRClientFactory
    {
        public static IServiceScope scope;

        public static void SetScope(IServiceProvider serviceProvider)
        {
            scope = serviceProvider.CreateScope();
        }

        public static SignalRClient GetSignalRClient()
        {
            return scope.ServiceProvider.GetRequiredService<SignalRClient>();
        }
    }
}
