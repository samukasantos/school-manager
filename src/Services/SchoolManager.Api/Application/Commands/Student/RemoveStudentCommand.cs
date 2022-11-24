using FluentValidation.Results;
using SchoolManager.Core.Messages;
using System;

namespace SchoolManager.Api.Application.Commands
{
    public class RemoveStudentCommand : Command
    {
        #region Properties

        public Guid Id { get; private set; }

        #endregion

        #region Constructor

        public RemoveStudentCommand(Guid id)
        {
            Id = id;
        }

        #endregion

        #region Methods

        public override bool IsValid()
        {
            if (Id == Guid.Empty)
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(Id), "Invalid identifier."));
            }

            return ValidationResult.IsValid;
        }

        #endregion
    }
}
