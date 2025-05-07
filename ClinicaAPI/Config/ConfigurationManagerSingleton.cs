using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaAPI.Data;
using ClinicaAPI.Config;

namespace ClinicaAPI.Config
{
    public sealed class ConfigurationManagerSingleton
    {
        private static readonly Lazy<ConfigurationManagerSingleton> instance =
            new Lazy<ConfigurationManagerSingleton>(() => new ConfigurationManagerSingleton());

        public static ConfigurationManagerSingleton Instance => instance.Value;

        public IConfiguration Configuration { get; }

        private ConfigurationManagerSingleton()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}