using MediatR;
using SchoolManager.Core.Messages;
using SchoolManager.Domain.Repositories;
using SchoolManager.Domain.ValueObjects;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation.Results;

namespace SchoolManager.Api.Application.Commands
{
    public class RemoveStudentCommandHandler : CommandHandler, IRequestHandler<RemoveStudentCommand, ValidationResult>
    {
        #region Fields

        private readonly IStudentRepository studentRepository;

        #endregion

        #region Constructor

        public RemoveStudentCommandHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        #endregion


        #region Methods

        public async Task<ValidationResult> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await studentRepository.DeleteAsync(request.Id);
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
