
using SchoolManager.Core.Messages;
using System.Threading.Tasks;

namespace SchoolManager.Services.Email
{
    public interface INotificationServiceProvider
    {
        Task SendNotificationAsync(Event @event);
    }
}