

using MediatR;
using System;

namespace SchoolManager.Core.Messages
{
    public class Event : Message, INotification
    {
        #region Properties

        public DateTime Timestamp { get; private set; }

        #endregion

        #region Constructor

        public Event()
        {
            Timestamp = DateTime.Now;
        }

        #endregion
    }
}
