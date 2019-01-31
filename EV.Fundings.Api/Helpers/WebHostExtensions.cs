using EV.Fundings.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV.Fundings.Api.Helpers
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedDatabase(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<EVDbContext>();
                context.Database.EnsureCreated();
            }
            return host;
        }
    }
}
