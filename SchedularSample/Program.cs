using System;
using System.IO;
using Coravel;
using Coravel.Scheduling.Schedule;
using Microsoft.AspNetCore.Builder.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SchedulerSample
{
    class Program
    {
        static void Main(string[] args)
        {

            var host = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, configApp) =>
                    {
                        configApp.SetBasePath(Directory.GetCurrentDirectory());
                        configApp.AddEnvironmentVariables(prefix: "PREFIX_");
                        configApp.AddCommandLine(args);
                    }).ConfigureServices((hostContext, services) =>
                {
                    services.AddScheduler();
                    services.AddTransient<TestInvocable>();
                })
                .Build();
            host.Services.UseScheduler(scheduler =>
            {
                scheduler.Schedule<TestInvocable>().EverySecond();
            });

            host.Run();
            Console.Read();

        }
    }
}
