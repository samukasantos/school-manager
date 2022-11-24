

using FluentValidation.Results;

namespace SchoolManager.Core.Messages
{
    public abstract class CommandHandler
    {
        #region Fields

        protected ValidationResult ValidationResult;

        #endregion

        #region Constructor

        public CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region Methods

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        #endregion
    }
}
