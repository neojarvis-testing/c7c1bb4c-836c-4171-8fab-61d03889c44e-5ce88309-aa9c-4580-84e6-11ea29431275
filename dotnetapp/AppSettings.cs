using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp
{
    public class AppSettings
    {
        public static string ApplicationDbConnectionString { get; set; } = string.Empty;

        public static void Init(IConfiguration configuration)
        {
            ApplicationDbConnectionString = ReadConnectionString(configuration, "ApplicationDb");
        }

        private static string ReadString(IConfiguration configuration, string variable)
        {
            return configuration.GetValue<string>(variable) ?? string.Empty;
        }

        private static string ReadConnectionString(IConfiguration configuration, string variable)
        {
            return configuration[$"ConnectionStrings:{variable}"] ?? string.Empty;
        }
    }
}