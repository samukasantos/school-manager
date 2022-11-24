
using FluentValidation.Results;
using MediatR;
using SchoolManager.Core.Messages;
using System.Threading.Tasks;

namespace SchoolManager.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        #region Fields

        private readonly IMediator mediator;

        #endregion

        #region Constructor

        public MediatorHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #endregion

        #region Methods
        public async Task PublishEventsAsync<T>(T @event) where T : Event
        {
            await mediator.Publish(@event);
        }

        public async Task<ValidationResult> SendCommandAsync<T>(T command) where T : Command
        {
            return await mediator.Send(command);
        }

        #endregion
    }
}
