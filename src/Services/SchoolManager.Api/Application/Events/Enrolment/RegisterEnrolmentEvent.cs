using SchoolManager.Core.Messages;
using System;

namespace SchoolManager.Api.Application.Events
{
    public class RegisterEnrolmentEvent : Event
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        #endregion

        #region Constructor

        public RegisterEnrolmentEvent(Guid id, string name, string subject)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            Subject = subject;
        }

        #endregion
    }
}
