﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Platform.Core.Common.Mapping;
using Optivem.Platform.Core.Common.Serialization;
using Optivem.Platform.Infrastructure.Common.Mapping.AutoMapper;
using Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper;
using Optivem.Platform.Test.Web.AspNetCore.Rest.Fake.Profiles.Customers;
using Optivem.Platform.Web.AspNetCore.Rest;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace Optivem.Platform.Test.Wed.AspNetCore.Rest.Fake
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICsvSerializationService, CsvSerializationService>();

            services.AddScoped<IMappingService, AutoMapperMappingService>();

            // Mapping
            // TODO: VC: DELETE

            /*
            services.AddAutoMapper(e =>
            {
                e.AddProfile<CustomerGetCollectionResponseProfile>();
            });
            */

            services.AddAutoMapper(Assembly.GetAssembly(typeof(CustomerGetCollectionResponseProfile)));

            // TODO: VC: AutoMapper: AssertConfigurationIsValid (example error: Count field is not mapped)

            services
                .AddMvc(options =>
                {
                    ICsvSerializationService csvSerializationService = new CsvSerializationService();

                    // TODO: VC: Consider using from resolver...
                    options.InputFormatters.Add(new CsvInputFormatter(csvSerializationService));
                    options.OutputFormatters.Add(new CsvOutputFormatter(csvSerializationService));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My Fake API", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Fake API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}