using System;
using Volo.Abp.Domain.Repositories;

namespace QMCommunication.QMPalabelCasecode
{
    public interface IPalabelCasecodeRepository : IRepository<PalabelCasecode, Guid>
    {
    }
}