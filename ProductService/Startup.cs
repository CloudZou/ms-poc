using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MediatR;
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
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic);
            builder.Services.AddMediatR(assemblies.ToArray());
        }
    }
}