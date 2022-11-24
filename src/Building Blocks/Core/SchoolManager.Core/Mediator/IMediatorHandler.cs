
using FluentValidation.Results;
using SchoolManager.Core.Messages;
using System.Threading.Tasks;

namespace SchoolManager.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEventsAsync<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommandAsync<T>(T command) where T : Command;
    }
}
