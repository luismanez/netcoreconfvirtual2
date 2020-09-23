using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delos.Westworld.Domain.Repositories;
using Delos.Westworld.Infrastructure.Persistence;
using Delos.Westworld.Infrastructure.Repositories;
using Delos.Westworld.ParksApi.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;

namespace Delos.Westworld.ParksApi
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
            services.AddPersistence(Configuration.GetConnectionString("WestworldDbContext"));

            services.AddMicrosoftIdentityWebApiAuthentication(Configuration)
                .EnableTokenAcquisitionToCallDownstreamApi()
                .AddInMemoryTokenCaches();

            // Reference on How you can add custom code to some Jwt Events:
            //services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
            //{
            //    var eventsOnAuthenticationFailed = options.Events.OnAuthenticationFailed;
            //    options.Events.OnAuthenticationFailed = async context =>
            //    {
            //        await eventsOnAuthenticationFailed(context);
            //        // Your code to add extra claims that will be executed after the current event implementation.
            //    };

            //    var eventsOnMessageReceived = options.Events.OnMessageReceived;
            //    options.Events.OnMessageReceived = async context =>
            //    {
            //        await eventsOnMessageReceived(context);
            //    };

            //    var eventsOnForbidden = options.Events.OnForbidden;
            //    options.Events.OnForbidden = async context =>
            //    {
            //        await eventsOnForbidden(context);
            //    };
            //});

            services.AddHttpClient<IEngineeringApiClient, EngineeringApiClient>(client => {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.BaseAddress = new Uri("https://localhost:44309");
            });

            services.AddScoped<IParkRepository, ParkRepository>();
            services.AddScoped<IHostRepository, HostRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
