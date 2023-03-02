using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QMCommunication.QMPalabelCasecode
{
    public static class PalabelCasecodeEfCoreQueryableExtensions
    {
        public static IQueryable<PalabelCasecode> IncludeDetails(this IQueryable<PalabelCasecode> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}