using FluentValidation.Results;
using SchoolManager.Core.Messages;
using System;

namespace SchoolManager.Api.Application.Commands
{
    public class RegisterSubjectCommand : Command
    {
        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        #endregion

        #region Constructor

        public RegisterSubjectCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;

            IsValid();
        }

        #endregion

        #region Methods

        public override bool IsValid()
        {
            if (Id == Guid.Empty)
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(Id), "Invalid identifier."));
            }

            if (string.IsNullOrEmpty(Name))
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(Name), "Subject name is required."));
            }

            if (string.IsNullOrEmpty(Description))
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(Description), "Subject description is required."));
            }

            return ValidationResult.IsValid;
        }

        #endregion
    }
}
