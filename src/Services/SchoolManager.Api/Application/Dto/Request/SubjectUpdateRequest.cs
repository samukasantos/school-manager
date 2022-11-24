using SchoolManager.Api.Application.Dto.Request.Base;
using System;

namespace SchoolManager.Api.Application.Dto.Request
{
    public class SubjectUpdateRequest : BaseRequest
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion

        #region Methods

        public override bool IsValid()
        {
            if (Id == Guid.Empty)
            {
                AddError(nameof(Id), "Invalid identifier.");
            }

            if (string.IsNullOrEmpty(Name))
            {
                AddError(nameof(Name), "Subject name is required");
            }

            if (string.IsNullOrEmpty(Description))
            {
                AddError(nameof(Description), "Subject description is required");
            }

            return ValidationResult.IsValid;
        }

        #endregion

    }
}
