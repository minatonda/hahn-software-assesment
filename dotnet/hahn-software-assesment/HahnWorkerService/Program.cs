using System.Net.Http;
using DataAccess.Repository;
using HahnDataAccess;
using HahnWorkerService;
using HahnWorkerServiceJobs.Dogs.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(builder =>
            {
                builder.Configure(app =>
                {
                    app.UseRouting();

                    app.UseHangfireDashboard();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapHangfireDashboard();
                    });
                });
            })
            .ConfigureServices((hostContext, services) =>
            {

                services.AddDbContext<ApplicationContext>(options =>
                {
                    // var folder = Environment.SpecialFolder.LocalApplicationData;
                    // var path = Environment.GetFolderPath(folder);
                    var dbPath = System.IO.Path.Join("../hahn.db");

                    options.UseSqlite($"Data Source={dbPath}",b=>b.MigrationsAssembly("HahnWorkerService"));
                    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                    options.EnableSensitiveDataLogging();
                });
                services.AddSingleton(new HttpClient()
                {
                    BaseAddress = new Uri("https://dogapi.dog/api/v2/")
                });

                services.AddTransient<BreedRepository, BreedRepository>();
                services.AddTransient<BreedAttributeBooleanRepository, BreedAttributeBooleanRepository>();
                services.AddTransient<BreedAttributeRangeRepository, BreedAttributeRangeRepository>();
                services.AddTransient<FetchJobService, FetchJobService>();
                services.AddHangfire(conf => conf.UseMemoryStorage());

                services.AddHangfireServer();

                services.AddHostedService<Worker>();
            });
}

var builder = CreateHostBuilder(args);

var host = builder.Build();
host.Run();

