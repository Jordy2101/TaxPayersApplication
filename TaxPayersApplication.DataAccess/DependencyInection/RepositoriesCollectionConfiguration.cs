using Microsoft.Extensions.DependencyInjection;
using TaxPayersApplication.DataAccess.Repositories;
using TaxPayersApplication.DataAccess.Repositories.Base;
using TaxPayersApplication.Domain.TaxPayersApplicationDB;

namespace TaxPayersApplication.DataAccess.DependencyInection
{
    public static class RepositoriesCollectionConfiguration
    {
        public static void AddRepositoriesCollections(this IServiceCollection service)
        {
            service.AddScoped<IBaseRepository<TaxPayers>, TaxPayersRepository>();
            service.AddScoped<IBaseRepository<TaxReceipt>, TaxReceiptRepository>();
        }
    }
}
