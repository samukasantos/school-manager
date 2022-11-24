using MediatR;
using System.Threading.Tasks;
using System.Threading;
using SchoolManager.Services.Email;

namespace SchoolManager.Api.Application.Events.Enrolment
{
    public class RegisterEnrolmentEventHandler : INotificationHandler<RegisterEnrolmentEvent>
    {

        #region Fields

        private readonly INotificationServiceProvider notificationProvider;

        #endregion

        #region Constructor

        public RegisterEnrolmentEventHandler(INotificationServiceProvider notificationProvider)
        {
            this.notificationProvider = notificationProvider;
        }

        #endregion

        #region Methods

        public async Task Handle(RegisterEnrolmentEvent notification, CancellationToken cancellationToken)
        {
            await notificationProvider.SendNotificationAsync(notification);
        }

        #endregion
    }
}
