using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;



namespace Nadine
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);        

            services.AddCors(options => options.AddPolicy("CorsPolicy", 
            builder => 
            {
                builder.AllowAnyMethod().AllowAnyHeader()
                    .WithOrigins("http://192.168.8.123:5000")
                    .AllowCredentials();
            }));

            services.AddSignalR();

            services.AddLogging();

            //services.AddHostedService<TimedHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseMvc();
            
            app.UseCors("CorsPolicy");

            app.UseSignalR(route =>
            {
                route.MapHub<Hubs.ChatHub>("/chathub");
                route.MapHub<Hubs.CounterHub>("/counterhub");
            });

            loggerFactory.AddDebug();
        }
    }
}
