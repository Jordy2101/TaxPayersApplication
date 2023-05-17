using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Domain.Base;

namespace TaxPayersApplication.Domain.TaxPayersApplicationDB
{
    [Table("TaxReceipt", Schema = "dbo")]
    public class TaxReceipt : BaseEntity
    {
        public string RncCedula { get; set; }
        public string NCF { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax18 { get; set; }
    }
}
