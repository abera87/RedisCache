using System.Threading.Tasks;
using StackExchange.Redis;

namespace BackOffice.Services
{
    public class RedisPublisherService:IPublishService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public RedisPublisherService(IConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer;
        }

        public Task PublishMessageAsync(string channel, string value)
        {
            var subscriber = connectionMultiplexer.GetSubscriber();

            return subscriber.PublishAsync(channel,value);
        }
    }
}