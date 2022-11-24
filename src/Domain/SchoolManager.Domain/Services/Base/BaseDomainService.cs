
using FluentValidation.Results;

namespace SchoolManager.Domain.Services.Base
{
    public abstract class BaseDomainService
    {
        #region Properties

        protected ValidationResult ValidationResult { get; private set; }

        #endregion

        #region Constructor

        protected BaseDomainService()
        {
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region Methods

        protected void AddError(string erroMessage) 
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, erroMessage));
        }

        #endregion
    }
}
