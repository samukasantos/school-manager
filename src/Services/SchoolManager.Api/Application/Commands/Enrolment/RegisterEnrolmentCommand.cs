using FluentValidation.Results;
using SchoolManager.Core.Messages;
using System;

namespace SchoolManager.Api.Application.Commands
{
    public class RegisterEnrolmentCommand : Command
    {
        #region Properties

        public Guid Id { get; private set; }
        public Guid StudentId { get; private set; }
        public Guid SubjectId { get; private set; }
        public DateTime StartAt { get; private set; }
        public DateTime EndAt { get; private set; }

        #endregion

        #region Constructor

        public RegisterEnrolmentCommand(Guid id, Guid studentId, Guid subjectId, DateTime startAt, DateTime endAt)
        {
            Id = id;
            StudentId = studentId;
            SubjectId = subjectId;
            StartAt = startAt;
            EndAt = endAt;
        }

        #endregion

        #region Methods

        public override bool IsValid()
        {
            if (StudentId == Guid.Empty)
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(StudentId), "Invalid student identifier."));
            }

            if (SubjectId == Guid.Empty)
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(SubjectId), "Invalid subject identifier."));
            }

            if (StartAt == DateTime.MinValue)
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(StartAt), "Invalid start date."));
            }

            if (EndAt == DateTime.MinValue)
            {
                ValidationResult.Errors.Add(new ValidationFailure(nameof(EndAt), "Invalid end date."));
            }

            if (StartAt > EndAt)
            {
                ValidationResult.Errors.Add(new ValidationFailure(string.Empty, "Start date must not be greater than the end date."));
            }

            return ValidationResult.IsValid;
        }

        #endregion
    }
}
