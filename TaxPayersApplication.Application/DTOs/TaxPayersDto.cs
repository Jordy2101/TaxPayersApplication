using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Application.DTOs.Base;

namespace TaxPayersApplication.Application.DTOs
{
    public class TaxPayersDto : BaseDto
    {
        public string RncCedula { get; set; }
        public string Name { get; set; }
        public string TypeTaxPayers { get; set; }
        public bool IsActive { get; set; }
    }
}
