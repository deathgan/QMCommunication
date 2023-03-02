using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace QMCommunication.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class QMCommunicationMigrationsDbContextFactory : IDesignTimeDbContextFactory<QMCommunicationMigrationsDbContext>
    {
        public QMCommunicationMigrationsDbContext CreateDbContext(string[] args)
        {
            QMCommunicationEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<QMCommunicationMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new QMCommunicationMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../QMCommunication.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
