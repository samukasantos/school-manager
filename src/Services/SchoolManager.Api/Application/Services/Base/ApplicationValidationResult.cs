using FluentValidation.Results;
using System;

namespace SchoolManager.Api.Application.Services.Base
{
    public class ApplicationValidationResult : ValidationResult
    {
        #region Fields

        public Guid Id { get; set; }
        public object DataResult { get; set; }

        #endregion

        #region Constructor

        public ApplicationValidationResult() { }

        #endregion

    }
}
