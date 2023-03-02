using QMCommunication.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QMCommunication
{
    [DependsOn(
        typeof(QMCommunicationEntityFrameworkCoreTestModule)
        )]
    public class QMCommunicationDomainTestModule : AbpModule
    {

    }
}