

using Bogus;
using Moq.AutoMock;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Dto.Response;
using System;
using System.Collections.Generic;
using Xunit;
using static Bogus.DataSets.Name;

namespace SchoolManager.Tests.ApplicationService
{
    [CollectionDefinition(nameof(ApplicationServiceCollection))]
    public class ApplicationServiceCollection : ICollectionFixture<EnrolmentApplicationServiceTestsFixture> { }

    public class EnrolmentApplicationServiceTestsFixture : IDisposable
    {
        #region Fields

        private readonly Faker faker = new Faker();

        #endregion

        #region Properties

        public AutoMocker Mocker { get; private set; }

        #endregion

        #region Constructor

        public EnrolmentApplicationServiceTestsFixture()
        {
            Mocker = new AutoMocker();
        }

        #endregion

        #region Methods

        private StudentResponse GetStudent()
        {
            return new StudentResponse
            {
                Id = Guid.NewGuid(),
                FirstName = faker.Name.FirstName(Gender.Male),
                LastName = faker.Name.LastName(Gender.Male),
                CreatedAt = DateTime.Now
            };
        }

        private SubjectResponse GetSubject()
        {
            return new SubjectResponse
            {
                Id = Guid.NewGuid(),
                Name = faker.Lorem.Word(),
                Description = faker.Lorem.Sentence(5)
            };
        }

        public EnrolmentRequest GetEnrolmentRequest()
        {
            var subject = GetSubject();
            var student = GetStudent();

            return new EnrolmentRequest
            {
                StudentId = student.Id,
                SubjectId = subject.Id,
                StartAt = DateTime.Now,
                EndAt = DateTime.Now.AddDays(2),
            };
        }

        public List<EnrolmentResponse> GetEnrolmentsResponse(int quantity)
        {
            var enrolments = new List<EnrolmentResponse>();

            for (int i = 0; i < quantity; i++)
            {
                enrolments.Add(new EnrolmentResponse
                {
                    Id = Guid.NewGuid(),
                    Name = $"{faker.Name.FirstName(Gender.Male)} {faker.Name.LastName(Gender.Male)}",
                    SubjectName = faker.Lorem.Word(),
                    StartAt = DateTime.Now,
                    EndAt = DateTime.Now.AddDays(2),
                });
            }

            return enrolments;
        }

        private List<SubjectResponse> GetSubjects(int quantity)
        {
            var subjects = new List<SubjectResponse>();

            for (int i = 0; i < quantity; i++)
            {
                subjects.Add(new SubjectResponse
                {
                    Id = Guid.NewGuid(),
                    Name = faker.Lorem.Word(),
                    Description = faker.Lorem.Sentence(5),
                    CreatedAt = DateTime.Now
                });
            }

            return subjects;
        }

        public void Dispose() { }

        #endregion
    }
}
