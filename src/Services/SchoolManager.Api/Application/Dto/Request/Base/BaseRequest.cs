using FluentValidation.Results;
using System.Collections.Generic;

namespace SchoolManager.Api.Application.Dto.Request.Base
{
    public abstract class BaseRequest
    {
        #region Fields

        protected ValidationResult ValidationResult;

        #endregion

        #region Properties

        public ICollection<ValidationFailure> Errors => ValidationResult.Errors;

        #endregion

        #region Constructor

        public BaseRequest()
        {
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region Methods

        public abstract bool IsValid();

        protected void AddError(string propertyName, string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
        }

        protected void AddError(string errorMessage)
        {
            AddError(string.Empty, errorMessage);
        }

        #endregion
    }
}
