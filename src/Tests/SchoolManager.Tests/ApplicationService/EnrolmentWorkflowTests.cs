
using FluentAssertions;
using MediatR;
using Moq;
using SchoolManager.Api.Application.Commands;
using SchoolManager.Api.Application.Dto.Response;
using SchoolManager.Api.Application.Queries.Base;
using SchoolManager.Api.Application.Queries.Interfaces;
using SchoolManager.Api.Application.Services;
using SchoolManager.Core.Mediator;
using SchoolManager.Core.Messages;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace SchoolManager.Tests.ApplicationService
{
    [Collection(nameof(ApplicationServiceCollection))]
    public class EnrolmentWorkflowTests
    {
        #region Fields

        private readonly EnrolmentApplicationServiceTestsFixture enrolmentTestFixture;

        #endregion

        #region Constructor

        public EnrolmentWorkflowTests(EnrolmentApplicationServiceTestsFixture enrolmentTestFixture)
        {
            this.enrolmentTestFixture = enrolmentTestFixture;
        }

        #endregion

        #region Methods

        //[Fact(DisplayName = "Register Enrolment")]
        //[Trait("Enrolment", "Register")]
        //public async void Given_EnrolmentWorklowIsExecuted_When_Success_ShouldReturnValidTransaction() 
        //{
        //    //Arrange
        //    var enrolmentRequest = enrolmentTestFixture.GetEnrolmentRequest();

        //    var mediator = enrolmentTestFixture.Mocker.GetMock<IMediator>();

        //    mediator.Setup(c => c.Send(It.IsAny<RegisterEnrolmentCommand>(), default));

        //    var mediatorHandler = new MediatorHandler(mediator.Object);

        //    var enrolmentApplicationService = new EnrolmentApplicationService(mediatorHandler, null);

        //    //Act
        //    enrolmentRequest.IsValid().Should().BeTrue();

        //    var result = await enrolmentApplicationService.RegisterAsync(enrolmentRequest);

        //    //Asserts
        //    //result.Should().Be(0);
        //}

        [Fact(DisplayName = "Visualize Enrolments")]
        [Trait("Enrolment", "View")]
        public async void Given_EnrolmentQueriesAllIsExecuted_When_Success_ShouldReturnAllEnrolments()
        {
            //Arrange
            var enrolmentQueries = enrolmentTestFixture.Mocker.GetMock<IEnrolmentQueries>();
            var enrolmentQuantity = 5;
            
            enrolmentQueries
                    .Setup(c => c.GetAllAsync())
                    .ReturnsAsync(new QueryValidationResult
                    {
                        DataResult = enrolmentTestFixture.GetEnrolmentsResponse(enrolmentQuantity)
                    });

            var enrolmentApplicationService = new EnrolmentApplicationService(It.IsAny<IMediatorHandler>(), enrolmentQueries.Object);

            //Act
            var result = await enrolmentApplicationService.GetAllAsync();
            var enrolments = result.DataResult as List<EnrolmentResponse>;

            //Assert
            result.IsValid.Should().BeTrue();
            result.DataResult.Should().NotBeNull();
            enrolments.Should().NotBeNull();
            enrolments.Count.Should().Be(enrolmentQuantity);
            enrolmentQueries.Verify(c => c.GetAllAsync(), Times.Once);
        }

        #endregion

    }

}
