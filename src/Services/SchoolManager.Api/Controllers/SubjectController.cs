using Microsoft.AspNetCore.Mvc;
using SchoolManager.Core.Mediator;
using SchoolManager.Api.Controllers.Base;
using Microsoft.Extensions.Logging;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Application.Services;
using System.Threading.Tasks;
using System;
using SchoolManager.Api.Application.Services.Interfaces;

namespace SchoolManager.Api.Controllers
{
    [Route("v{version:apiVersion}/subject")]
    [ApiVersion("1.0")]
    public class SubjectController : BaseController
    {
        #region Fields

        private readonly ILogger<SubjectController> logger;
        private readonly ISubjectApplicationService subjectApplicationService;

        #endregion


        #region Constructor

        public SubjectController(ISubjectApplicationService subjectApplicationService, ILogger<SubjectController> logger)
        {
            this.subjectApplicationService = subjectApplicationService;
            this.logger = logger;
        }

        #endregion

        #region Methods


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await subjectApplicationService.GetAllAsync();

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

        [HttpGet("{id:guid}", Name = nameof(GetSubjectByIdAsync))]
        public async Task<IActionResult> GetSubjectByIdAsync([FromRoute] Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequestResponse("Invalid identifier.");
                }

                var result = await subjectApplicationService.GetByIdAsync(id);

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
        public async Task<IActionResult> PostAsync(SubjectRequest subjectRequest)
        {
            try
            {
                if (!subjectRequest.IsValid())
                {
                    return BadRequestResponse("The submitted data is invalid.", subjectRequest.Errors);
                }

                var result = await subjectApplicationService.RegisterAsync(subjectRequest);

                if (!result.IsValid)
                {
                    return BadRequestResponse("The submitted data is invalid.", result.Errors);
                }

                return CreatedResponse(nameof(GetSubjectByIdAsync), result.Id, result.DataResult);
            }
            catch (Exception e)
            {
                logger.LogTrace(e, e.Message);

                return InternalServerErrorResponse(e.Message);
            }
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PatchAsync([FromRoute] Guid id, SubjectUpdateRequest subjectRequest)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequestResponse("Invalid identifier.");
                }

                if (!subjectRequest.IsValid())
                {
                    return BadRequestResponse("The submitted data is invalid.", subjectRequest.Errors);
                }

                if (id != subjectRequest.Id)
                {
                    return BadRequestResponse("Invalid identifier.");
                }

                var result = await subjectApplicationService.UpdateAsync(subjectRequest);

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

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequestResponse("Invalid identifier.");
                }

                var student = await subjectApplicationService.GetByIdAsync(id);

                if (student.DataResult == null)
                {
                    return NotFoundResponse("Resource not found.");
                }

                var result = await subjectApplicationService.RemoveAsync(id);

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
