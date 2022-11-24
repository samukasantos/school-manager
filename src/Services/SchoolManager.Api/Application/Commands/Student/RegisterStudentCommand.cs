using FluentValidation.Results;
using SchoolManager.Core.Messages;
using System;

namespace SchoolManager.Api.Application.Commands
{
    public class RegisterStudentCommand : Command
    {
        #region Properties

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        #endregion

        #region Constructor

        public RegisterStudentCommand(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;

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

            if (string.IsNullOrEmpty(FirstName))
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(FirstName), "FirstName is required."));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(LastName), "LastName is required."));
            }

            return ValidationResult.IsValid;
        } 
        
        #endregion
    }
}
