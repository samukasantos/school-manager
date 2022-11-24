
using FluentValidation.Results;

namespace SchoolManager.Core.ValueObjects.Base
{
    public abstract class BaseValueObject : ValueObject
    {
        #region Properties

        public ValidationResult ValidationResult { get; private set; }

        #endregion

        #region Constructor

        protected BaseValueObject() 
        {
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region Methods

        protected void AddError(string propertyName, string errorMessage) 
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
        }

        public abstract bool IsValid(); 

        #endregion
    }
}
