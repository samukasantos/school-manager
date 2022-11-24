using SchoolManager.Api.Application.Commands;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Dto.Response;
using SchoolManager.Api.Application.Queries.Interfaces;
using SchoolManager.Api.Application.Services.Base;
using SchoolManager.Api.Application.Services.Interfaces;
using SchoolManager.Core.Mediator;
using System.Threading.Tasks;
using System;
using SchoolManager.Api.Adapters;

namespace SchoolManager.Api.Application.Services
{
    public class EnrolmentApplicationService : BaseApplicationService, IEnrolmentApplicationService
    {
        #region Fields

        private readonly IMediatorHandler handler;
        private readonly IEnrolmentQueries enrolmentQueries;

        #endregion

        #region Constructor

        public EnrolmentApplicationService(IMediatorHandler handler, IEnrolmentQueries enrolmentQueries)
        {
            this.handler = handler;
            this.enrolmentQueries = enrolmentQueries;
        }

        #endregion

        #region Methods

        public async Task<ApplicationValidationResult> RegisterAsync(EnrolmentRequest request)
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

            ValidationResult.DataResult = new EnrolmentIdResponse
            {
                Id = command.Id
            };

            return ValidationResult;
        }

        public async Task<ApplicationValidationResult> RemoveAsync(Guid id)
        {
            var command = new RemoveEnrolmentCommand(id);

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
            var result = await enrolmentQueries.GetAllAsync();

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
            var result = await enrolmentQueries.GetByIdAsync(id);

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
