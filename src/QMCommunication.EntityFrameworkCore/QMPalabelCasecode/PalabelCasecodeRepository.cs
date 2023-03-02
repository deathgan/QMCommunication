using System;
using QMCommunication.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace QMCommunication.QMPalabelCasecode
{
    public class PalabelCasecodeRepository : EfCoreRepository<QMCommunicationDbContext, PalabelCasecode, Guid>, IPalabelCasecodeRepository
    {
        public PalabelCasecodeRepository(IDbContextProvider<QMCommunicationDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}