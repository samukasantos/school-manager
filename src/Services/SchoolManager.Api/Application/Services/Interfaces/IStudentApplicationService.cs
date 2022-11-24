using FluentValidation.Results;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Queries.Base;
using SchoolManager.Api.Application.Services.Base;
using System;
using System.Threading.Tasks;

namespace SchoolManager.Api.Application.Services.Interfaces
{
    public interface IStudentApplicationService
    {
        Task<ApplicationValidationResult> RegisterAsync(StudentRequest request);
        Task<ApplicationValidationResult> UpdateAsync(StudentUpdateRequest request);
        Task<ApplicationValidationResult> RemoveAsync(Guid id);
        Task<ApplicationValidationResult> GetAllAsync();
        Task<ApplicationValidationResult> GetByIdAsync(Guid id);
    }
}
