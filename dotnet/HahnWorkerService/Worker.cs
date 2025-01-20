using HahnWorkerServiceJobs.Dogs.Jobs;

namespace HahnWorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceProvider _serviceProvider;

    public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var scope = _serviceProvider.CreateScope()) // this will use `IServiceScopeFactory` internally
        {
            RunFetchJob(scope,stoppingToken);
        }
    }

    private async Task RunFetchJob(IServiceScope scope, CancellationToken stoppingToken)
    {
        var fetchJobService = scope.ServiceProvider.GetService<FetchJobService>();
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            Hangfire.BackgroundJob.Enqueue(() => fetchJobService.FetchData());
            await Task.Delay(3600000, stoppingToken);
        }
    }
}
