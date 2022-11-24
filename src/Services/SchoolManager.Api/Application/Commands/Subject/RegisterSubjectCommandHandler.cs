using FluentValidation.Results;
using MediatR;
using SchoolManager.Core.Messages;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManager.Api.Application.Commands
{
    public class RegisterSubjectCommandHandler : CommandHandler, IRequestHandler<RegisterSubjectCommand, ValidationResult>
    {
        #region Fields

        private readonly ISubjectRepository subjectRepository;

        #endregion

        #region Constructor

        public RegisterSubjectCommandHandler(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        #endregion


        #region Methods

        public async Task<ValidationResult> Handle(RegisterSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {   
                var subject = new Subject(request.Id, request.Name, request.Description);

                await subjectRepository.AddAsync(subject);
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
