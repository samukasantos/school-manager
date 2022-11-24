using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Services.Base;
using System.Threading.Tasks;
using System;

namespace SchoolManager.Api.Application.Services.Interfaces
{
    public interface ISubjectApplicationService
    {
        Task<ApplicationValidationResult> RegisterAsync(SubjectRequest request);
        Task<ApplicationValidationResult> UpdateAsync(SubjectUpdateRequest request);
        Task<ApplicationValidationResult> RemoveAsync(Guid id);
        Task<ApplicationValidationResult> GetAllAsync();
        Task<ApplicationValidationResult> GetByIdAsync(Guid id);
    }
}
