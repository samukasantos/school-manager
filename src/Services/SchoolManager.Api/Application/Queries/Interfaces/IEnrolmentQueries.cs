using SchoolManager.Api.Application.Queries.Base;
using System;
using System.Threading.Tasks;

namespace SchoolManager.Api.Application.Queries.Interfaces
{
    public interface IEnrolmentQueries
    {
        Task<QueryValidationResult> GetAllAsync();
        Task<QueryValidationResult> GetByIdAsync(Guid id);
    }
}
