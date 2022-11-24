

using FluentValidation.Results;
using MediatR;
using System;

namespace SchoolManager.Core.Messages
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        #region Properties

        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        #endregion

        #region Constructor

        public Command()
        {
            Timestamp = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region Methods

        public abstract bool IsValid();

        #endregion
    }
}
