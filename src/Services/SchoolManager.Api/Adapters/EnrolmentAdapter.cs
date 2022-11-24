using SchoolManager.Api.Application.Commands;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Dto.Response;
using SchoolManager.Domain.Entities;
using System.Collections.Generic;
using System;

namespace SchoolManager.Api.Adapters
{
    public static class EnrolmentAdapter
    {
        public static RegisterEnrolmentCommand ToCommand(this EnrolmentRequest enrolmentRequest)
        {
            return new RegisterEnrolmentCommand
                (
                    Guid.NewGuid(), 
                    enrolmentRequest.StudentId, 
                    enrolmentRequest.SubjectId,
                    enrolmentRequest.StartAt,
                    enrolmentRequest.EndAt
                );
        }

        public static EnrolmentResponse ToResponse(this Enrolment enrolment)
        {
            return new EnrolmentResponse
            {
                Id = enrolment.Id,
                SubjectName = enrolment.Subject.Name,
                Name = enrolment.Student.ToString(),
                StartAt = enrolment.StartAt,
                EndAt = enrolment.EndAt
            };
        }

        public static List<EnrolmentResponse> ToCollectionResponse(this ICollection<Enrolment> enrolments)
        {
            var currentEnrolments = new List<EnrolmentResponse>();

            foreach (var enrolment in enrolments)
            {
                currentEnrolments.Add(enrolment.ToResponse());
            }

            return currentEnrolments;
        }
    }
}
