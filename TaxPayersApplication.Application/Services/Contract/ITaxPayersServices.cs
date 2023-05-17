using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Application.DTOs;
using TaxPayersApplication.Common.Dtos;
using TaxPayersApplication.Common.Filters;

namespace TaxPayersApplication.Application.Services.Contract
{
    public interface ITaxPayersServices
    {
        Task<Pagination> GetPagedtaxPayers(TaxPayersFilter filter);
        Task<int> Create(TaxPayersDto data);
        Task<bool> InactiveTaxPayers(int id);
    }
}
