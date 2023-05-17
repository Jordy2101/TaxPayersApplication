using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Application.DTOs.Base;

namespace TaxPayersApplication.Application.DTOs
{
    public class TaxReceiptDto : BaseDto
    {
        public string RncCedula { get; set; }
        public string NCF { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax18 { get; set; }
    }
}
