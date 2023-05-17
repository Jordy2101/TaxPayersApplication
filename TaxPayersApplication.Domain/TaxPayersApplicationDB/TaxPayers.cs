using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Domain.Base;

namespace TaxPayersApplication.Domain.TaxPayersApplicationDB
{
    [Table("TaxPayers", Schema = "dbo")]
    public class TaxPayers : BaseEntity
    {
        public string RncCedula { get; set; }
        public string Name { get; set; }
        public string TypeTaxPayers { get; set; }
        public bool IsActive { get; set; }
    }
}
