using Microsoft.EntityFrameworkCore;
using TaxPayersApplication.DataAccess.DBContexts;

namespace TaxPayersApplication.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddContextInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaxPayersApplicationContext>(options => options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:TaxPayersApplicationConnection")));
        }
    }
}
