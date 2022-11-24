using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManager.Api.Application.Commands;
using SchoolManager.Api.Application.Events;
using SchoolManager.Api.Application.Events.Enrolment;
using SchoolManager.Api.Application.Queries;
using SchoolManager.Api.Application.Queries.Interfaces;
using SchoolManager.Api.Application.Services;
using SchoolManager.Api.Application.Services.Interfaces;
using SchoolManager.Api.Data.Repositories;
using SchoolManager.Api.Services;
using SchoolManager.Core.Mediator;
using SchoolManager.Domain.Repositories;
using SchoolManager.Domain.Services;
using SchoolManager.Domain.Services.Interfaces;
using SchoolManager.Services.Email;

namespace SchoolManager.Api.Configuration
{
    public static class DependencyConfigurationExtensions
    {
        public static void AddDependencyServices(this IServiceCollection services, IConfiguration configuration)
        {

            //ApplicationServices
            services.AddScoped<IStudentApplicationService, StudentApplicationService>();
            services.AddScoped<IEnrolmentApplicationService, EnrolmentApplicationService>();
            services.AddScoped<ISubjectApplicationService, SubjectApplicationService>();

            //DomainServices
            services.AddScoped<IEnrolmentDomainService, EnrolmentDomainService>();

            //Events
            services.AddScoped<INotificationHandler<RegisterEnrolmentEvent>, RegisterEnrolmentEventHandler>();

            //Notification
            services.AddScoped<INotificationServiceProvider, NotificationServiceProvider>();

            //Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IEnrolmentRepository, EnrolmentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            //Queries
            services.AddScoped<ISubjectQueries, SubjectQueries>();
            services.AddScoped<IStudentQueries, StudentQueries>();
            services.AddScoped<IEnrolmentQueries, EnrolmentQueries>();

            //Handlers
            services.AddScoped<IRequestHandler<RegisterStudentCommand, ValidationResult>, RegisterStudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, ValidationResult>, UpdateStudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, ValidationResult>, RemoveStudentCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterStudentCommand, ValidationResult>, RegisterStudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, ValidationResult>, UpdateStudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, ValidationResult>, RemoveStudentCommandHandler>();

            //Services
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }
    }
}
