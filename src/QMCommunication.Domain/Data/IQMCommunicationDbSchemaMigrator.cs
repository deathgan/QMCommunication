using System.Threading.Tasks;

namespace QMCommunication.Data
{
    public interface IQMCommunicationDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
