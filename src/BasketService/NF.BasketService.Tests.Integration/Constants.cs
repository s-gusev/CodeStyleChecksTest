using System.IO;

namespace BasketService.Tests.Integration
{
    public class Constants
    {
        public static string BasketDbConnectionString { get; } = GetDatabaseFilePath();

        private static string GetDatabaseFilePath()
        {
            string currentAssemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string currentDirName = Path.GetDirectoryName(currentAssemblyLocation);
            return Path.GetFullPath(Path.Combine(currentDirName, @"..\..\..\..\..\..\DATABASES\\NOSQL\\BasketService.db"));
        }
    }
}
