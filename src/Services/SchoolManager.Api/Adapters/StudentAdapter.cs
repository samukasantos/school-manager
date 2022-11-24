using SchoolManager.Api.Application.Commands;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Dto.Response;
using SchoolManager.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SchoolManager.Api.Adapters
{
    public static class StudentAdapter
    {
        public static RegisterStudentCommand ToCommand(this StudentRequest studentRequest)
        {
            return new RegisterStudentCommand(Guid.NewGuid(), studentRequest.FirstName, studentRequest.LastName);
        }

        public static UpdateStudentCommand ToCommand(this StudentUpdateRequest studentRequest)
        {
            return new UpdateStudentCommand(studentRequest.Id, studentRequest.FirstName, studentRequest.LastName);
        }

        public static StudentResponse ToResponse(this Student student)
        {
            return new StudentResponse
            {
                Id = student.Id,
                FirstName = student.Name.FirstName,
                LastName = student.Name.LastName,
                CreatedAt = student.CreatedAt
            };
        }

        public static List<StudentResponse> ToCollectionResponse(this ICollection<Student> students)
        {
            var currentStudents = new List<StudentResponse>();

            foreach (var student in students)
            {
                currentStudents.Add(student.ToResponse());
            }

            return currentStudents;
        }
    }
}
