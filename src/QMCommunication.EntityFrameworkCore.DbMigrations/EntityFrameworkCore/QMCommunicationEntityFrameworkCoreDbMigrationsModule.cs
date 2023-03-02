using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace QMCommunication.EntityFrameworkCore
{
    [DependsOn(
        typeof(QMCommunicationEntityFrameworkCoreModule)
        )]
    public class QMCommunicationEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<QMCommunicationMigrationsDbContext>();
        }
    }
}
