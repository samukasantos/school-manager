using FluentValidation.Results;

namespace SchoolManager.Api.Application.Queries.Base
{
    public class QueryValidationResult : ValidationResult
    {
        public object DataResult { get; set; }
    }
}
