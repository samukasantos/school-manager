using FluentValidation.Results;

namespace SchoolManager.Api.Application.Queries.Base
{
    public abstract class BaseQuery
    {
        #region Properties

        public QueryValidationResult ValidationResult { get; private set; }

        #endregion

        #region Constructor

        public BaseQuery()
        {
            ValidationResult = new QueryValidationResult();
        }

        #endregion

        #region Methods

        protected void AddError(string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, errorMessage));
        }

        #endregion    
    }
}
