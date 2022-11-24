using MediatR;
using SchoolManager.Core.Messages;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Repositories;
using SchoolManager.Domain.ValueObjects;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation.Results;
using SchoolManager.Domain.Services.Interfaces;
using SchoolManager.Api.Application.Events;
using SchoolManager.Core.Mediator;

namespace SchoolManager.Api.Application.Commands
{
    public class RegisterEnrolmentCommandHandler : CommandHandler, IRequestHandler<RegisterEnrolmentCommand, ValidationResult>
    {
        #region Fields

        private readonly IEnrolmentRepository enrolmentRepository;
        private readonly ISubjectRepository subjectRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IEnrolmentDomainService enrolmentDomainService;
        private readonly INotificationHandler<RegisterEnrolmentEvent> notificationHandler;
        private readonly IPublisher publisher;

        #endregion

        #region Constructor

        public RegisterEnrolmentCommandHandler(
            IEnrolmentDomainService enrolmentDomainService,
            ISubjectRepository subjectRepository,
            IStudentRepository studentRepository,
            IEnrolmentRepository enrolmentRepository,
            IPublisher publisher)
        {
            this.enrolmentRepository = enrolmentRepository;
            this.subjectRepository = subjectRepository;
            this.studentRepository = studentRepository;
            this.enrolmentDomainService = enrolmentDomainService;
            this.publisher = publisher;
        }

        #endregion


        #region Methods

        public async Task<ValidationResult> Handle(RegisterEnrolmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var subject = await subjectRepository.GetByIdAsync(request.SubjectId);

                if(subject == null) 
                {
                    AddError("Failed to create enrolment.");
                }

                var student = await studentRepository.GetByIdAsync(request.StudentId);

                if (student == null)
                {
                    AddError("Failed to create enrolment.");
                }

                if (!enrolmentDomainService.IsElegibleToEnrol(student.Enrolments))
                {
                    AddError("Student not eligible to enrol, there are more than 5 incomplete subjects.");
                }
                else 
                {
                    var enrolment = new Enrolment(request.Id, student.Id, subject.Id, request.StartAt, request.EndAt);

                    await enrolmentRepository.AddAsync(enrolment);

                    await publisher.Publish(new RegisterEnrolmentEvent(request.Id, student.Name.ToString(), subject.Name));
                }
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
