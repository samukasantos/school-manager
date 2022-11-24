using FluentValidation.Results;
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
    public class StudentApplicationService : BaseApplicationService, IStudentApplicationService
    {
        #region Fields

        private readonly IMediatorHandler handler;
        private readonly IStudentQueries studentQueries;


        #endregion

        #region Constructor

        public StudentApplicationService(IMediatorHandler handler, IStudentQueries studentQueries)
        {
            this.handler = handler;
            this.studentQueries = studentQueries;
        }

        #endregion

        #region Methods

        public async Task<ApplicationValidationResult> RegisterAsync(StudentRequest request) 
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

            ValidationResult.DataResult = new StudentResponse
            {
                Id = command.Id,
                FirstName = command.FirstName,
                LastName = command.LastName
            };

            return ValidationResult;
        }

        public async Task<ApplicationValidationResult> UpdateAsync(StudentUpdateRequest request)
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
            var command = new RemoveStudentCommand(id);

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
            var result = await studentQueries.GetAllAsync();

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
            var result = await studentQueries.GetByIdAsync(id);

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
