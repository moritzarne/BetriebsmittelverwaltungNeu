using Betriebsmittelverwaltung.Areas.Identity.Data;
using Betriebsmittelverwaltung.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betriebsmittelverwaltung
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
            services.AddDbContext<BetriebsmittelverwaltungContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("BetriebsmittelverwaltungContextConnection")));

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<BetriebsmittelverwaltungContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateUsersRoles(um, rm).Wait();

        }

        private async Task CreateUsersRoles(UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            AppUser user = await um.FindByNameAsync("admin@admin.de");
            if (user == null)
            {
                user = new AppUser() { Email = "admin@admin.de", UserName = "admin@admin.de" };
                await um.CreateAsync(user, "_Admin123");
            }

            IdentityRole role = await rm.FindByNameAsync("Administrator");

            if (role == null)
            {
                role = new IdentityRole("Administrator");
                await rm.CreateAsync(role);
            }

            IdentityRole roleTwo = await rm.FindByNameAsync("Bauleiter");

            if (roleTwo == null)
            {
                role = new IdentityRole("Bauleiter");
                await rm.CreateAsync(role);
            }

            IdentityRole roleThree = await rm.FindByNameAsync("Lagerist");

            if (roleThree == null)
            {
                role = new IdentityRole("Lagerist");
                await rm.CreateAsync(role);
            }

            bool inrole = await um.IsInRoleAsync(user, "Administrator");
            if (!inrole)
            {
                await um.AddToRoleAsync(user, "Administrator");
            }

            return;
        }
    }
}
