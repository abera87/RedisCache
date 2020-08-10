using System.Threading.Tasks;

namespace BackOffice.Services
{
    public interface IPublishService
    {
        Task PublishMessageAsync(string channel, string value);
    }
}