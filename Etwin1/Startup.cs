using Etwin.BAL.Services;
using Etwin.DAL.DataRepository;
using Etwin.DAL.Models;
using EtwLogin.Models;
using EtwLogin.Repository;
using EtwLogin.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etwin1
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
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            services.AddControllersWithViews();
            
            services.AddScoped<AuthenticationService>();
            services.AddScoped<IAuthenticateLogin, AuthenticateLogin>();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            //services.AddTransient<IMailService, MailService>();
            var ConnectionString = Configuration.GetConnectionString("MbkDbConstr");
            services.AddDbContext<ETWLoginContext
                >(options => options.UseSqlServer(ConnectionString));
            services.AddScoped<DepartmentRepositoryService, DepartmentRepositoryService>();
            services.AddTransient<IGenericRepository<Departments>, GenericRepository<Departments>>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
