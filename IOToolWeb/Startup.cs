using IOToolDataLibrary.Data;
using IOToolDataLibrary.Db;
using IOToolWeb.Business;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace IOToolWeb
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
            services.AddControllersWithViews();
            services.AddSingleton(new ConnectionStringData
            {
                SqlConnectionName = "Default"
            });
            //Data access should not be singleton. Should be transient or scoped
            services.AddTransient<IDataAccess, SqlDb>();
            services.AddTransient<IUsersData, UsersData>();
            services.AddTransient<ITransportersData, TransportersData>();
            services.AddTransient<ICountriesData, CountriesData>();
            services.AddTransient<ICitiesData, CitiesData>();
            services.AddTransient<IRequestTypesData, RequestTypesData>();
            services.AddTransient<ISuppliersData, SuppliersData>();
            services.AddTransient<IPricesData, PricesData>();
            services.AddTransient<IRequestsData, RequestsData>();
            services.AddTransient<IRequestInfoData, RequestInfoData>();
            services.AddTransient<IEmailsToSendData, EmailsToSendData>();
            services.AddTransient<IEmailGroupsData, EmailGroupsData>();
            services.AddTransient<ISmtpData, SmtpData>();
            services.AddTransient<IPriceLogic, PriceLogic>();
            services.AddTransient<ICostCentersData, CostCentersData>();


            services.AddHttpContextAccessor();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
           // services.AddAuthentication(IISDefaults.AuthenticationScheme);


            services.AddDistributedMemoryCache();

            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;



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
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Authentication}/{action=Index}/{id?}");
            });
        }
    }
}
