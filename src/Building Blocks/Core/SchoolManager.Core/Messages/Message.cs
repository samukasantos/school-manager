

using System;

namespace SchoolManager.Core.Messages
{
    public abstract class Message
    {
        #region Properties

        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        #endregion

        #region Constructor

        public Message()
        {
            MessageType = GetType().Name;
        }

        #endregion
    }
}
