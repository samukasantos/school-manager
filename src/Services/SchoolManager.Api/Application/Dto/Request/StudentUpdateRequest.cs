using SchoolManager.Api.Application.Dto.Request.Base;
using System;

namespace SchoolManager.Api.Application.Dto.Request
{
    public class StudentUpdateRequest : BaseRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        #endregion

        #region Methods
        
        public override bool IsValid()
        {
            if (Id == Guid.Empty)
            {
                AddError(nameof(Id), "Invalid identifier.");
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                AddError(nameof(FirstName), "FirstName is required.");
            }

            if (string.IsNullOrEmpty(LastName))
            {
                AddError(nameof(LastName), "LastName is required.");
            }

            return ValidationResult.IsValid;
        }

        #endregion
    }
}
