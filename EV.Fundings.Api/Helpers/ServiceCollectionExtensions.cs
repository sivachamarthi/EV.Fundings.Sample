using EV.Fundings.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;

namespace EV.Fundings.Api.Helpers
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Extension method adding swagger to the DI container 
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info
                {
                    Title = "EV Funding Api",
                    Version = "v1",
                    Description = "Engel and Volkers Funding api.",
                    Contact = new Contact
                    {
                        Name = "Engel and Volkers",
                        Email = "support@ev-capital.de",
                        Url = "https://www.ev-capital.de/"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }
    }
}
