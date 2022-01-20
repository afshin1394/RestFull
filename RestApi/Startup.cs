using ApplicationService.DareRepository;
using ApplicationService.DareRepository.ViewModels.DareViewModel.Inputs;
using ApplicationService.QuestionR;
using ApplicationService.QuestionRepository.ViewModels.QuestionViewModel.Inputs;
using EFDataAccessLibrary.Commons;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
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


namespace RestApi
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

            //services.AddMvc().AddControllersAsServices();
            services.AddControllers();
            services.AddHttpContextAccessor();
            //services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.IgnoreNullValues = true;
            //});
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
                services.AddDbContext<AppDBContext>();

            });
            services.AddScoped<IRepository<DareInput>, DareRepository>();

            services.AddScoped<IRepository<QuestionInput>, QuestionRepository>();


            //services
            //.AddMvcCore(options =>
            //{
            //    options.RequireHttpsPermanent = true; // does not affect api requests
            //    options.RespectBrowserAcceptHeader = true; // false by default
            //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();

            //remove these two below, but added so you know where to place them...

            //})
            //.AddApiExplorer()
            //.AddAuthorization()
            //.AddFormatterMappings();
            //.AddCacheTagHelper()
            //.AddDataAnnotations()
            //.AddCors()

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
               
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

        

         


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
