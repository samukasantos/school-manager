using SchoolManager.Api.Adapters;
using SchoolManager.Api.Application.Commands;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Dto.Response;
using SchoolManager.Api.Application.Queries.Interfaces;
using SchoolManager.Api.Application.Services.Base;
using SchoolManager.Api.Application.Services.Interfaces;
using SchoolManager.Core.Mediator;
using System;
using System.Threading.Tasks;

namespace SchoolManager.Api.Application.Services
{
    public class SubjectApplicationService : BaseApplicationService, ISubjectApplicationService
    {
        #region Fields

        private readonly IMediatorHandler handler;
        private readonly ISubjectQueries subjectQueries;

        #endregion

        #region Constructor

        public SubjectApplicationService(IMediatorHandler handler, ISubjectQueries subjectQueries)
        {
            this.handler = handler;
            this.subjectQueries = subjectQueries;
        }

        #endregion

        #region Methods

        public async Task<ApplicationValidationResult> RegisterAsync(SubjectRequest request)
        {
            var command = request.ToCommand();

            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    AddError(error);
                }
            }

            ValidationResult.Id = command.Id;

            var result = await handler.SendCommandAsync(command);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    AddError(error);
                }
            }

            ValidationResult.DataResult = new SubjectResponse
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Description
            };

            return ValidationResult;
        }

        public async Task<ApplicationValidationResult> UpdateAsync(SubjectUpdateRequest request)
        {
            var command = request.ToCommand();

            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    AddError(error);
                }
            }

            var result = await handler.SendCommandAsync(command);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    AddError(error);
                }
            }

            return ValidationResult;
        }

        public async Task<ApplicationValidationResult> RemoveAsync(Guid id)
        {
            var command = new RemoveSubjectCommand(id);

            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    AddError(error);
                }
            }

            var result = await handler.SendCommandAsync(command);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    AddError(error);
                }
            }

            return ValidationResult;
        }

        public async Task<ApplicationValidationResult> GetAllAsync()
        {
            var result = await subjectQueries.GetAllAsync();

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    AddError(error);
                }
            }

            if (ValidationResult.IsValid)
            {
                ValidationResult.DataResult = result.DataResult;
            }

            return ValidationResult;
        }

        public async Task<ApplicationValidationResult> GetByIdAsync(Guid id)
        {
            var result = await subjectQueries.GetByIdAsync(id);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    AddError(error);
                }
            }

            if (ValidationResult.IsValid)
            {
                ValidationResult.DataResult = result.DataResult;
            }

            return ValidationResult;
        }

        #endregion
    }
}
