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
    public class RegisterStudentCommandHandler : CommandHandler, IRequestHandler<RegisterStudentCommand, ValidationResult>
    {
        #region Fields

        private readonly IStudentRepository studentRepository;

        #endregion

        #region Constructor

        public RegisterStudentCommandHandler(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        #endregion


        #region Methods
        
        public async Task<ValidationResult> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var name = new Name(request.FirstName, request.LastName);

                if (!name.IsValid())
                {
                    foreach (var error in name.ValidationResult.Errors)
                    {
                        AddError(error.ErrorMessage);
                    }
                }

                var student = new Student(request.Id, name);

                await studentRepository.AddAsync(student);
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
