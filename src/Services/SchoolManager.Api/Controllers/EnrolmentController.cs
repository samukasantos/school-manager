using Microsoft.AspNetCore.Mvc;
using SchoolManager.Core.Mediator;
using SchoolManager.Api.Controllers.Base;
using Microsoft.Extensions.Logging;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace SchoolManager.Api.Controllers
{
    [Route("v{version:apiVersion}/enrolment")]
    [ApiVersion("1.0")]
    public class EnrolmentController : BaseController
    {
        #region Fields

        private readonly ILogger<EnrolmentController> logger;
        private readonly IEnrolmentApplicationService enrolmentApplicationService;

        #endregion

        #region Constructor

        public EnrolmentController(IEnrolmentApplicationService enrolmentApplicationService,ILogger<EnrolmentController> logger)
        {
            this.enrolmentApplicationService = enrolmentApplicationService;
            this.logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await enrolmentApplicationService.GetAllAsync();

                if (!result.IsValid)
                {
                    return BadRequestResponse("The submitted data is invalid.", result.Errors);
                }

                return OkResponse("Success", result.DataResult);
            }
            catch (Exception e)
            {
                logger.LogTrace(e, e.Message);

                return InternalServerErrorResponse(e.Message);
            }
        }

        [HttpGet("{id:guid}", Name = nameof(GetEnrolmentByIdAsync))]
        public async Task<IActionResult> GetEnrolmentByIdAsync([FromRoute] Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequestResponse("Invalid identifier.");
                }

                var result = await enrolmentApplicationService.GetByIdAsync(id);

                if (result.DataResult == null)
                {
                    return NotFoundResponse("Resource not found.");
                }

                if (!result.IsValid)
                {
                    return BadRequestResponse("The submitted data is invalid.", result.Errors);
                }

                return OkResponse("Success", result.DataResult);
            }
            catch (Exception e)
            {
                logger.LogTrace(e, e.Message);

                return InternalServerErrorResponse(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(EnrolmentRequest enrolmentRequest)
        {
            try
            {
                if (!enrolmentRequest.IsValid())
                {
                    return BadRequestResponse("The submitted data is invalid.", enrolmentRequest.Errors);
                }

                var result = await enrolmentApplicationService.RegisterAsync(enrolmentRequest);

                if (!result.IsValid)
                {
                    return BadRequestResponse("The submitted data is invalid.", result.Errors);
                }

                return CreatedResponse(nameof(GetEnrolmentByIdAsync), result.Id, result.DataResult);
            }
            catch (Exception e)
            {
                logger.LogTrace(e, e.Message);

                return InternalServerErrorResponse(e.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequestResponse("Invalid identifier.");
                }

                var student = await enrolmentApplicationService.GetByIdAsync(id);

                if (student.DataResult == null)
                {
                    return NotFoundResponse("Resource not found.");
                }

                var result = await enrolmentApplicationService.RemoveAsync(id);

                if (!result.IsValid)
                {
                    return BadRequestResponse("The submitted data is invalid.", result.Errors);
                }

                return NoContectResponse();
            }
            catch (Exception e)
            {
                logger.LogTrace(e, e.Message);

                return InternalServerErrorResponse(e.Message);
            }
        }

        #endregion
    }
}
