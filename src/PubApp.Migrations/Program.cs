using DbUp;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace PubApp.Migrations
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString = args.FirstOrDefault(a => a.Trim() != "--fromconsole") ??
                ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            Console.WriteLine($"Running migration on {connectionStringBuilder.DataSource}");

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .WithTransactionPerScript()
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
