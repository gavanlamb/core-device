using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.Device.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration">Configuration properties</param>
        /// <param name="environmentVariableName">Name of the environment variable that contains the environment name</param>
        /// <param name="firstMessage">First message to print out</param>
        public static void AddSerilog(
            IConfiguration configuration,
            string environmentVariableName = "ASPNETCORE_ENVIRONMENT",
            string firstMessage = "Application started")
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(configuration)
                .CreateLogger();
            Log.Information(firstMessage);
        }
    }
}