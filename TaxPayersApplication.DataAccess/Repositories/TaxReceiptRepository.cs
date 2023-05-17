using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.DataAccess.DBContexts;
using TaxPayersApplication.DataAccess.Repositories.Base;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;

namespace TaxPayersApplication.DataAccess.Repositories
{
    public class TaxReceiptRepository : BaseRepository<TaxReceipt>
    {
        public TaxReceiptRepository(TaxPayersApplicationContext ctx) : base(ctx)
        {

        }
    }
}
