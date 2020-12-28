using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorRentCar.Areas.Identity;
using BlazorRentCar.Data;
using Blazored.Toast;
using BlazorRentCar.Models;
using BlazorRentCar.BLL;
using BlazorRentCar.ApplicationState;

namespace BlazorRentCar {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<Contexto>(options =>
                options.UseSqlite(
                    "Data source=Data\\CodeRentCarDB.db") , ServiceLifetime.Transient);

            services.AddDefaultIdentity<Usuarios>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole<string>>()
                .AddEntityFrameworkStores<Contexto>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider , RevalidatingIdentityAuthenticationStateProvider<Usuarios>>();

            services.AddScoped<AppState>();

            services.AddBlazoredToast();
            services.AddTransient<ClientesBLL>();
            services.AddScoped<IUserClaimsPrincipalFactory<Usuarios> , MyUserClaimsPrincipalFactory>();
            services.AddTransient<UserInfoBLL>();
            services.AddTransient<VehiculoBLL>();
            services.AddTransient<VentasBLL>();
            services.AddTransient<RentasBLL>();
            services.AddTransient<CuotasBLL>();
            services.AddTransient<CobrosBLL>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app , IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
