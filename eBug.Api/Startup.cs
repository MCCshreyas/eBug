using eBug.Api.Filters;
using eBug.Application;
using eBug.Infrastructure;
using eBug.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace eBug.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure();
            services.AddPersistence(Configuration);

            services.AddCors(option =>
            {
                option.AddPolicy("AnyOriginAnyMethod",builder =>
                {
                    builder.WithOrigins(Configuration["UIEndpoint"])
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddControllers(option =>
            {
                option.Filters.Add(new ApiExceptionFilterAttribute());
            }).AddFluentValidation();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "eBug.Api", Version = "v1"}); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eBug.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AnyOriginAnyMethod");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}