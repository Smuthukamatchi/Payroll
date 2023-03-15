using PayrollApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Session;

namespace PayrollApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            services.AddSingleton(configuration);
            services.AddOptions();
            services.AddControllersWithViews();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDistributedMemoryCache();
            services.AddSingleton<ISessionStore, DistributedSessionStore>();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // services.AddDefaultIdentity<>().AddEntityFrameworkStores<ApplicationDbContext>();

        }
        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "Admin/{controller=AddEmployee}/{action=Index}/{id?}",
                    defaults: new {area = "Admin" }
                    );
                    // endpoints.MapDefaultControllerRoute();
                // endpoints.MapControllerRoute(
                //         name: "Default",
                //         pattern: "{controller}/{action}/{id?}",
                //         defaults: new { controller = "Home", action = "Index" }
                //     );
            });
        }
    }
}