using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmokeApp_Storage.Models;
using Microsoft.EntityFrameworkCore;
using SmokeApp_Storage.Interfaces;
using SmokeApp_Storage.Repositories;

namespace SmokeAppApi
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

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IDiscussionRepo, DiscussionRepo>();
            services.AddScoped<ISubscriptionRepo, SubscriptionRepo>();
            //services.AddScoped<ISubscriptionRepo, SubscriptionRepo>();
            services.AddCors((options) =>
            {
                options.AddPolicy(name: "dev", builder =>
                {
                    builder.WithOrigins(
                        "http://localhost:4200",
                        "https://localhost:5001",
                        "https://localhost:44348",
                        "http://localhost:5000"
                        )
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmokeAppApi", Version = "v1" });
            });


            services.AddDbContext<SmokeDBContext>(options => {
                //if db options is already configured, dont do anything otherwise use the connection string I have in secrets.json
                if (!options.IsConfigured)
                {
                    options.UseSqlServer(Configuration.GetConnectionString("AzureDB"));
                }
            });//end addition here
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmokeAppApi v1"));
            }

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("dev");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
