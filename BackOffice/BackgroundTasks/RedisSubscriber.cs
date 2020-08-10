using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace BackOffice.BackgroundTasks
{
    public class RedisSubscriber : BackgroundService
    {
        private IConnectionMultiplexer connectionMultiplexer;
        public RedisSubscriber(IConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer;
        }
        // this method will run as backend job when application start
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriber = connectionMultiplexer.GetSubscriber();
            return subscriber.SubscribeAsync("message", (channel, value) =>
                 Console.WriteLine($"The message content was: {value}")
            );
        }
    }
}