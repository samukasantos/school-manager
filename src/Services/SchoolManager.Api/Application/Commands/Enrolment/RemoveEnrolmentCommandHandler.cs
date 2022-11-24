using MediatR;
using SchoolManager.Core.Messages;
using SchoolManager.Domain.Repositories;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation.Results;

namespace SchoolManager.Api.Application.Commands
{
    public class RemoveEnrolmentCommandHandler : CommandHandler, IRequestHandler<RemoveEnrolmentCommand, ValidationResult>
    {
        #region Fields

        private readonly IEnrolmentRepository enrolmentRepository;

        #endregion

        #region Constructor

        public RemoveEnrolmentCommandHandler(IEnrolmentRepository enrolmentRepository)
        {
            this.enrolmentRepository = enrolmentRepository;
        }

        #endregion


        #region Methods

        public async Task<ValidationResult> Handle(RemoveEnrolmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await enrolmentRepository.DeleteAsync(request.Id);
            }
            catch (Exception e)
            {
                AddError(e.Message);
            }

            return ValidationResult;
        }

        #endregion
    }
}
