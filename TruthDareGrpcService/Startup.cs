using ApplicationService.QuestionR;
using ApplicationService.QuestionRepository.ViewModels.QuestionViewModel.Inputs;
using EFDataAccessLibrary.Commons;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TruthDareGrpcService.Dare.Protos;
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
