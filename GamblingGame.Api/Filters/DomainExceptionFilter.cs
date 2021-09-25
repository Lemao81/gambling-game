using System;
using GamblingGame.Api.Models.Dtos;
using GamblingGame.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamblingGame.Api.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        public async void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case DomainException domainException:
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Result = new JsonResult(new ErrorResponse
                    {
                        Reason = domainException.Reason
                    });
                    break;
                case UnauthorizedAccessException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.HttpContext.Response.WriteAsync("Unauthorized access");
                    break;
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.HttpContext.Response.WriteAsync("Internal server error");
                    break;
            }

            context.ExceptionHandled = true;
        }
    }
}
