using Microsoft.AspNetCore.Mvc;
using WebApiTest.book;
using WebApiTest;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace WebApiTest
{
    public class Startup {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            
        {          
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1");
                });
                app.UseDeveloperExceptionPage();
            }
                
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddDbContext<ApplicationDbContext>(option => option.UseNpgsql(_configuration.GetConnectionString("DefaultConnectionStrings")));
           
            services.AddSwaggerGen(swagger =>
            {
                swagger.CustomSchemaIds(type => type.ToString());
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Description = "ASP.NET Core 5.0 Web API"
                });
            });
        }      
        }
    } 
