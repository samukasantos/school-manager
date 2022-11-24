using SchoolManager.Api.Application.Dto.Request.Base;
using SchoolManager.Domain.ValueObjects;

namespace SchoolManager.Api.Application.Dto.Request
{
    public class SubjectRequest : BaseRequest
    {
        #region Properties
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion

        #region Methods

        public override bool IsValid()
        {
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
