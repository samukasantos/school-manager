using FluentValidation.Results;
using MediatR;
using SchoolManager.Core.Messages;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Repositories;
using SchoolManager.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManager.Api.Application.Commands
{
    public class UpdateStudentCommandHandler : CommandHandler, IRequestHandler<UpdateStudentCommand, ValidationResult>
    {
        #region Fields

        private readonly IStudentRepository studentRepository;

        #endregion

        #region Constructor

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        #endregion

        #region Methods
        
        public async Task<ValidationResult> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var student = await studentRepository.GetByIdAsync(request.Id);

                var name = new Name(request.FirstName, request.LastName);

                if (!name.IsValid())
                {
                    foreach (var error in name.ValidationResult.Errors)
                    {
                        AddError(error.ErrorMessage);
                    }
                }

                student.ChangeName(name);

                await studentRepository.UpdateAsync(student);
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
