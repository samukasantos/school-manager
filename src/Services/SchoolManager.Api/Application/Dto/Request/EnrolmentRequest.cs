using SchoolManager.Api.Application.Dto.Request.Base;
using System;

namespace SchoolManager.Api.Application.Dto.Request
{
    public class EnrolmentRequest : BaseRequest
    {
        #region Properties
        
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        #endregion

        #region Methods

        public override bool IsValid()
        {

            if (StudentId == Guid.Empty)
            {
                AddError(nameof(StudentId), "Invalid student identifier.");
            }

            if (SubjectId == Guid.Empty)
            {
                AddError(nameof(SubjectId), "Invalid subject identifier.");
            }

            if (StartAt == DateTime.MinValue)
            {
                AddError(nameof(StartAt), "Invalid start date.");
            }

            if (EndAt == DateTime.MinValue)
            {
                AddError(nameof(EndAt), "Invalid end date.");
            }

            if (StartAt > EndAt)
            {
                AddError("Start date must not be greater than the end date.");
            }

            return ValidationResult.IsValid;
        }

        #endregion
    }
}
