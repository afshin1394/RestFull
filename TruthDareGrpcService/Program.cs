using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using TruthDareGrpcService.Services;
using TruthDareGrpcService.Protos;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace TruthDareGrpcService
{
    public class Program
    {

     
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
           
            

            Console.WriteLine("Accounts server listening on port " + 5001);
            Console.WriteLine("Press any key to stop " +
                "the server ...");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
              
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(options =>
                    {
                        // set http2 protocol
                        options.ConfigureEndpointDefaults(endpoints => endpoints.Protocols = HttpProtocols.Http2);
                    });
                    webBuilder.ConfigureKestrel(options =>
                    {
                        options.ListenAnyIP(5000);
                    });
                });
         
    }
}
