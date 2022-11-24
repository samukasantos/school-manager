using Microsoft.AspNetCore.Mvc;
using SchoolManager.Core.Mediator;
using SchoolManager.Api.Controllers.Base;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using SchoolManager.Api.Application.Services.Interfaces;
using SchoolManager.Api.Application.Dto.Request;
using SchoolManager.Api.Adapters;
using SchoolManager.Domain.ValueObjects;

namespace SchoolManager.Api.Controllers
{
    [Route("v{version:apiVersion}/student")]
    [ApiVersion("1.0")]
    public class StudentController : BaseController
    {
        #region Fields

        private readonly ILogger<StudentController> logger;
        private readonly IStudentApplicationService studentApplicationService;

        #endregion

        #region Constructor

        public StudentController(IStudentApplicationService studentApplicationService, ILogger<StudentController> logger)
        {
            this.studentApplicationService = studentApplicationService;
            this.logger = logger;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var result = await studentApplicationService.GetAllAsync();

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

        [HttpGet("{id:guid}", Name = nameof(GetStudentByIdAsync))]
        public async Task<IActionResult> GetStudentByIdAsync([FromRoute] Guid id)
        {
            try
            {
                if (id == Guid.Empty) 
                {
                    return BadRequestResponse("Invalid identifier.");
                }

                var result = await studentApplicationService.GetByIdAsync(id);

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
        public async Task<IActionResult> PostAsync(StudentRequest studentRequest)
        {
            try
            {
                if (!studentRequest.IsValid()) 
                {
                    return BadRequestResponse("The submitted data is invalid.", studentRequest.Errors);
                }

                var result = await studentApplicationService.RegisterAsync(studentRequest);

                if (!result.IsValid) 
                {
                    return BadRequestResponse("The submitted data is invalid.", result.Errors);
                }
                
                return CreatedResponse(nameof(GetStudentByIdAsync), result.Id, result.DataResult);
            }
            catch (Exception e)
            {
                logger.LogTrace(e, e.Message);

                return InternalServerErrorResponse(e.Message);
            }
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PatchAsync([FromRoute] Guid id, StudentUpdateRequest studentRequest)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequestResponse("Invalid identifier.");
                }

                if (!studentRequest.IsValid())
                {
                    return BadRequestResponse("The submitted data is invalid.", studentRequest.Errors);
                }

                if (id != studentRequest.Id) 
                {
                    return BadRequestResponse("Invalid identifier.");
                }

                var result = await studentApplicationService.UpdateAsync(studentRequest);

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

                var student = await studentApplicationService.GetByIdAsync(id);

                if (student.DataResult == null)
                {
                    return NotFoundResponse("Resource not found.");
                }

                var result = await studentApplicationService.RemoveAsync(id);

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
