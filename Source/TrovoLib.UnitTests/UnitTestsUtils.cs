using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace TrovoLib.UnitTests
{
    internal static class UnitTestsUtils
    {
        internal static IConfigurationRoot LoadConfiguration()
            => new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true)
                .Build();
    }
}
