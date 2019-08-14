using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ProductService;

[assembly:FunctionsStartup(typeof(ProductServiceApp))]
namespace ProductService
{
    public class ProductServiceApp: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
//            builder.Services.AddMediatR();

        }
    }
}