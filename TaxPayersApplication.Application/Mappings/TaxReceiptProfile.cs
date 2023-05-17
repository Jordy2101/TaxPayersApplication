using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Application.DTOs;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;

namespace TaxPayersApplication.Application.Mappings
{
    public class TaxReceiptProfile : Profile
    {
        public TaxReceiptProfile() 
        {
            CreateMap<TaxReceipt, TaxReceiptDto>().ReverseMap();
        }
    }
}
