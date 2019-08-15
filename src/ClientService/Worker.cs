using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            int i = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _configuration["login:username"] = i.ToString();
                _logger.LogInformation($"Configuration test : {_configuration.GetSection("login:username").Value }");
                i++;

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
