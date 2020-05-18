using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using Core.Devices.Api.Extensions;
using Core.Devices.Api.Models.Settings;
using Core.Devices.Api.Repositories;
using Core.Devices.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Core.Devices.Api
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
            services.AddControllers();
            services
                .AddMvc()
                .AddJsonOptions(config =>
                {
                    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    config.JsonSerializerOptions.IgnoreNullValues = true;
                    config.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            services.AddHttpContextAccessor();
            services.AddSingleton<IDeviceRepository, DeviceRepository>();
            services.AddSingleton<IUserDeviceService, UserDeviceService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Thing Cloud Device API",
                    Description = "Thing Cloud Device API"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.CustomSchemaIds(x => x.FullName);
            });
            
            services.Configure<DevicesDatabaseSettings>(Configuration.GetSection("DevicesDatabaseSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceCollectionExtensions.AddSerilog(Configuration);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Thing Cloud Device API"));

            app.UseRouting();
            app.UseCors();
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}