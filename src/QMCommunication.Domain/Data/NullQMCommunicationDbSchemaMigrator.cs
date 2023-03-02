using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace QMCommunication.Data
{
    /* This is used if database provider does't define
     * IQMCommunicationDbSchemaMigrator implementation.
     */
    public class NullQMCommunicationDbSchemaMigrator : IQMCommunicationDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}