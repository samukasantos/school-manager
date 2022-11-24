using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManager.Api.Controllers.Base
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        #region Methods

        protected IActionResult OkResponse(string message, object data = null)
        {
            if(data == null) 
            {
                return Ok(new
                {
                    Code = StatusCodes.Status200OK,
                    Message = message
                });
            }

            return Ok(new
            {
                Code = StatusCodes.Status200OK,
                Message = message,
                Data = data
            });
        }

        protected IActionResult CreatedResponse(string actionName, Guid resourceId, object data)
        {
            return CreatedAtRoute(actionName, new { id = resourceId.ToString() }, data);
        }

        protected IActionResult NoContectResponse()
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

        protected IActionResult BadRequestResponse(string message, ICollection<ValidationFailure> errors)
        {
            return BadRequest(new
            {
                Code = StatusCodes.Status400BadRequest,
                Message = message,
                Errors = errors.Select(error => new
                {
                    Code = string.IsNullOrEmpty(error.ErrorCode)
                                ? StatusCodes.Status400BadRequest
                                : int.Parse(error.ErrorCode),
                    Message = error.ErrorMessage
                })
            }); ;
        }

        protected IActionResult BadRequestResponse(string message)
        {
            return BadRequest(new
            {   
                Message = message
            });
        }

        protected IActionResult NotFoundResponse(string message)
        {
            return NotFound(new
            {
                Code = StatusCodes.Status404NotFound,
                Message = message
            });
        }

        protected IActionResult InternalServerErrorResponse(string message)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Code = StatusCodes.Status500InternalServerError,
                Message = message
            });
        }

        #endregion
    }
}
