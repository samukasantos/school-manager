using FluentValidation.Results;

namespace SchoolManager.Api.Application.Services.Base
{
    public class BaseApplicationService
    {
        #region Fields

        protected readonly ApplicationValidationResult ValidationResult;

        #endregion

        #region Constructor

        protected BaseApplicationService()
        {
            ValidationResult = new ApplicationValidationResult();
        }

        #endregion

        #region Methods

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected void AddError(ValidationFailure failure)
        {
            ValidationResult.Errors.Add(failure);
        }

        #endregion
    }
}
