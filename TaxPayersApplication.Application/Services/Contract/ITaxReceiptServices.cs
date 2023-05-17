using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Application.DTOs;

namespace TaxPayersApplication.Application.Services.Contract
{
    public interface ITaxReceiptServices
    {
        Task<List<TaxReceiptDto>> GetReceiptByPayers(string id);
        Task<bool> CreateReceiptPayers(TaxReceiptDto data);
        Task<string> GetNFC();
    }
}
