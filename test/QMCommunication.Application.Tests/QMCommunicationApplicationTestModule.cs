using Volo.Abp.Modularity;

namespace QMCommunication
{
    [DependsOn(
        typeof(QMCommunicationApplicationModule),
        typeof(QMCommunicationDomainTestModule)
        )]
    public class QMCommunicationApplicationTestModule : AbpModule
    {

    }
}