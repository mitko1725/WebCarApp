using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebCarApp.Data;
using WebCarApp.Services;
using WebCarApp.Services.Interfaces;
using WebCarApp.Web;
using WebCarApp.Web.Hubs;

namespace WebCarApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services )
        {

         

            services.AddDbContext<CarDbContex>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CarDbContex")));
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddControllersWithViews();
           
            services.AddSignalR();

            string pathToContentRoot = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process).Equals("Development", StringComparison.InvariantCultureIgnoreCase) ?
        Directory.GetCurrentDirectory() :
        Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            services.AddTransient<IFileLogger>(s => new FileLogger(Configuration, pathToContentRoot));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Home/Error");
                //app.UseExceptionHandler("/Error");
        
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapHub<CarHub>("/carhub");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
