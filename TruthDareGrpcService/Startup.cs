using ApplicationService.DareRepository;
using ApplicationService.DareRepository.ViewModels.DareViewModel.Inputs;
using ApplicationService.QuestionR;
using ApplicationService.QuestionRepository.ViewModels.QuestionViewModel.Inputs;
using AutoMapper;
using EFDataAccessLibrary.Commons;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruthDareGrpcService.Dare.Protos;
using TruthDareGrpcService.Protos;
using TruthDareGrpcService.Services;


namespace TruthDareGrpcService
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        QuestionService question { get; }
       
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        


            //services.AddScoped<QuestionService>();
            services.AddGrpc();
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IRepository<QuestionInput>, QuestionRepository>();
            //services.AddSingleton<IRepository<Dare>, DareRepository>();




            //      services.AddTransient<IHandler<Question>, QuestionHandler>();




        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
         {
             endpoints.MapGrpcService<QuestionService>();
             endpoints.MapGrpcService<DareService>();

         });
        }
    }
}
