using QMCommunication.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace QMCommunication.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(QMCommunicationEntityFrameworkCoreDbMigrationsModule),
        typeof(QMCommunicationApplicationContractsModule)
        )]
    public class QMCommunicationDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
