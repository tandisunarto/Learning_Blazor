using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BethanysPieShopHRM.UI.Services;
using BethanysPieShopHRM.UI.Data;
using Blazor.FlexGrid;
using BethanysPieShopHRM.UI.Pages;
using BethanysPieShopHRM.UI.Extensions;
using System;

namespace BethanysPieShopHRM.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
            
            var pieShopURI = new Uri("https://localhost:44340");
            var recruitingURI = new Uri("https://localhost:44350");

            services.RegisterHttpClient<IEmployeeDataService, EmployeeDataService>(pieShopURI);
            services.RegisterHttpClient<ICountryDataService, CountryDataService>(pieShopURI);
            services.RegisterHttpClient<IJobCategoryDataService, JobCategoryDataService>(pieShopURI);
            services.RegisterHttpClient<ITaskDataService, TaskDataService>(pieShopURI);
            services.RegisterHttpClient<ISurveyDataService, SurveyDataService>(pieShopURI);
            services.RegisterHttpClient<IExpenseDataService, ExpenseDataService>(pieShopURI);
            services.RegisterHttpClient<ICurrencyDataService, CurrencyDataService>(pieShopURI);
            services.RegisterHttpClient<IJobDataService, JobsDataService>(recruitingURI);

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IExpenseApprovalService, ExpenseApprovalService>();

            services.AddProtectedBrowserStorage();

            services.AddFlexGridServerSide(cfg =>
            {
                cfg.ApplyConfiguration(new ExpenseGridConfiguration());
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseFlexGrid(env.WebRootPath);
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
