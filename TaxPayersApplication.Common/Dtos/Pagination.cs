using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxPayersApplication.Common.Dtos
{
    public class Pagination
    {
        public int? TotalCount { get; set; }
        public int? PageSize { get; set; }
        public int? CurrentPage { get; set; }
        public int? TotalPages { get; set; }
        public int? HasNext { get; set; }
        public int? HasPrevious { get; set; }
        public object Data { get; set; }
    }
}
