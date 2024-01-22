using DesafioNetCore.Domain.Entities.Common;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DesafioNetCore.Application.Middleware;

public class ExceptionMiddleware : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			ErrorResult errorResult = new()
			{
				ErrorId = Guid.NewGuid().ToString(),
				Exception = ex.Message.Trim(),
			};
			
            var problemDetails = new ProblemDetails
            {
                Instance = context.Request.Path
            };

            if (ex is ValidationException validationException)
            {
                var validationErrors = validationException.Errors
                .Select(error => error.ErrorMessage).ToList();
                problemDetails.Extensions.Add("errors", validationErrors);
                problemDetails.Title = "one or more validation errors occurred.";
                problemDetails.Status = StatusCodes.Status400BadRequest;
            }

            errorResult.StatusCode = (int)GetErrorStatusCode(ex);

			HttpResponse response = context.Response;
			response.ContentType = "application/json";
			response.StatusCode = errorResult.StatusCode;

			await response.WriteAsJsonAsync(problemDetails);
		}
	}

	private HttpStatusCode GetErrorStatusCode(Exception exception)
	{
		switch (exception)
		{
			case KeyNotFoundException:
				return HttpStatusCode.NotFound;
            case InvalidOperationException:
            case ValidationException:
				return HttpStatusCode.UnprocessableEntity;
			case UnauthorizedAccessException:
				return HttpStatusCode.Unauthorized;
     
            default:
				return HttpStatusCode.InternalServerError;
        }
	}
}
