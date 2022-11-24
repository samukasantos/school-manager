using SchoolManager.Api.Application.Events;
using SchoolManager.Core.Messages;
using SchoolManager.Services.Email;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SchoolManager.Api.Services
{
    public class NotificationServiceProvider : INotificationServiceProvider
    {
        #region Methods
        
        public async Task SendNotificationAsync(Event @event)
        {
            var path = "c:\\schoolmanager-temp\\";

            if (!Directory.Exists(path)) 
            {
                Directory.CreateDirectory(path);
            }

            if (@event is RegisterEnrolmentEvent register)
            {
                var text = $"{register.Name} has enrolled in {register.Subject} | Date { DateTime.Now }. Congratulations !";

                await File.WriteAllTextAsync($"{path}enrolment-{Guid.NewGuid()}.txt", text);
            }
            else 
            {
                var text = $"Unmapped operation has been executed. - {@event.AggregateId}";

                await File.WriteAllTextAsync($"{path}generic-ops-{Guid.NewGuid()}.txt", text);
            }
        } 
        
        #endregion
    }
}
