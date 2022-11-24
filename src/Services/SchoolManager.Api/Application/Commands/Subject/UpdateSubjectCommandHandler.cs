using FluentValidation.Results;
using MediatR;
using SchoolManager.Api.Data.Repositories;
using SchoolManager.Core.Messages;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Repositories;
using SchoolManager.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManager.Api.Application.Commands
{
    public class UpdateSubjectCommandHandler : CommandHandler, IRequestHandler<UpdateSubjectCommand, ValidationResult>
    {
        #region Fields

        private readonly ISubjectRepository subjectRepository;

        #endregion

        #region Constructor

        public UpdateSubjectCommandHandler(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        #endregion

        #region Methods

        public async Task<ValidationResult> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var subject = await subjectRepository.GetByIdAsync(request.Id);

                subject.ChangeName(request.Name);
                subject.ChangeDescription(request.Description);

                if (!subject.IsValid())
                {
                    foreach (var error in subject.ValidationResult.Errors)
                    {
                        AddError(error.ErrorMessage);
                    }
                }

                await subjectRepository.UpdateAsync(subject);
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
