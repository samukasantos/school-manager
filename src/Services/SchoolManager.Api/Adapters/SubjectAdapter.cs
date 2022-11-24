using SchoolManager.Api.Application.Commands;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Dto.Response;
using SchoolManager.Domain.Entities;
using System.Collections.Generic;
using System;

namespace SchoolManager.Api.Adapters
{
    public static class SubjectAdapter
    {
        public static RegisterSubjectCommand ToCommand(this SubjectRequest subjectRequest)
        {
            return new RegisterSubjectCommand(Guid.NewGuid(), subjectRequest.Name, subjectRequest.Description);
        }

        public static UpdateSubjectCommand ToCommand(this SubjectUpdateRequest subjectRequest)
        {
            return new UpdateSubjectCommand(subjectRequest.Id, subjectRequest.Name, subjectRequest.Description);
        }

        public static SubjectResponse ToResponse(this Subject subject)
        {
            return new SubjectResponse
            {
                Id = subject.Id,
                Name = subject.Name,
                Description  = subject.Description,
                CreatedAt = subject.CreatedAt
            };
        }

        public static List<SubjectResponse> ToCollectionResponse(this ICollection<Subject> subjects)
        {
            var currentSubjects= new List<SubjectResponse>();

            foreach (var subject in subjects)
            {
                currentSubjects.Add(subject.ToResponse());
            }

            return currentSubjects;
        }
    }
}
