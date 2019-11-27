using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;




namespace SoftServe.BookingSectors.Helpers
{
    /// <summary>
    /// Helper for obtaining connection data
    /// </summary>
    public static class ConfigurationHelper
    {
        private static string connection;

        /// <summary>
        /// Get database connection string
        /// </summary>
        /// <returns></returns>
        public static string GetDatabaseConnectionString()
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = GetAppSettingsValue();
            }


            return connection;
        }



        private static string GetAppSettingsValue()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var value = config.GetValue<string>("ServiceBusConnectionString");


            return value;
        }
    }
}
