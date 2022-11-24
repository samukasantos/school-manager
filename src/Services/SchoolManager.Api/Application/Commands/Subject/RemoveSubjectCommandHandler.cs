using MediatR;
using SchoolManager.Core.Messages;
using SchoolManager.Domain.Repositories;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation.Results;

namespace SchoolManager.Api.Application.Commands
{
    public class RemoveSubjectCommandHandler : CommandHandler, IRequestHandler<RemoveSubjectCommand, ValidationResult>
    {
        #region Fields

        private readonly ISubjectRepository subjectRepository;

        #endregion

        #region Constructor

        public RemoveSubjectCommandHandler(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        #endregion


        #region Methods

        public async Task<ValidationResult> Handle(RemoveSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await subjectRepository.DeleteAsync(request.Id);
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
