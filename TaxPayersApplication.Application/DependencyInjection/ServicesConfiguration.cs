using AutoMapper.Execution;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaxPayersApplication.Application.Services;
using TaxPayersApplication.Application.Services.Base;
using TaxPayersApplication.Application.Services.Contract;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;

namespace TaxPayersApplication.Application.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IServicesBase<TaxPayers>, TaxPayersServices>();
            services.AddScoped<IServicesBase<TaxReceipt>, TaxReceiptServices>();
            services.AddScoped<ITaxPayersServices, TaxPayersServices>();
            services.AddScoped<ITaxReceiptServices, TaxReceiptServices>(); 
        }
    }
}
