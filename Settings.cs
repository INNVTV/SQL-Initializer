using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using SqlFactory.Models;

namespace SqlFactory
{
    public static class Settings
    {
        public static AppSettings GetAppSettings()
        {
            //Get configuration from Docker/Compose (via .env and appsettings.json)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables(); //<-- Allows for Docker Env Variables

            IConfigurationRoot configuration = builder.Build();

            var _databaseName = configuration["Application:DatabaseName"];
            var _schemaName = configuration["Application:SchemaName"];

            var appSettings = new AppSettings{
                    databaseName = _databaseName,
                    schemaName = _schemaName
                };

            return appSettings;
        }

        public static SqlSettings GetSqlSettings()
        {
            //Get configuration from Docker/Compose (via .env and appsettings.json)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables(); //<-- Allows for Docker Env Variables

            IConfigurationRoot configuration = builder.Build();

            var _server = configuration["Sql:Server"];
            var _userName = configuration["Sql:UserName"];
            var _password = configuration["Sql:Password"];

            var sqlSettings = new SqlSettings{
                    server = _server,
                    userName = _userName,
                    password = _password
                };

            return sqlSettings;
        }
    }
}