

using SchoolManager.Core.DomainObjects;
using SchoolManager.Domain.Base;
using System;

namespace SchoolManager.Domain.Entities
{
    public class Enrolment : BaseEntity, IAggregateRoot
    {
        #region Properties
        
        public Student Student { get; private set; }
        public Guid StudentId { get; private set; }
        public Subject Subject { get; private set; }
        public Guid SubjectId { get; private set; }
        public DateTime StartAt { get; private set; }
        public DateTime EndAt { get; private set; }

        #endregion

        #region Constructor

        protected Enrolment() { }
        public Enrolment(Guid id, Guid studentId, Guid subjectId, DateTime startAt, DateTime endAt)
            : base(id)
        {
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
                AddError(nameof(StartAt), "Invalid student identifier.");
            }

            if (SubjectId == Guid.Empty)
            {
                AddError(nameof(StartAt), "Invalid subject identifier.");
            }

            if (StartAt == DateTime.MinValue) 
            {
                AddError(nameof(StartAt), "Invalid start date.");
            }

            if (EndAt == DateTime.MinValue)
            {
                AddError(nameof(EndAt), "Invalid end date.");
            }

            if(StartAt < EndAt) 
            {
                AddError("Start date must be greater than the end date.");
            }

            return ValidationResult.IsValid;
        }

        #endregion
    }
}
