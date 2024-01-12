using DesafioNetCore.Domain.Entities.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace DesafioNetCore.Application.Middleware;

public class ExceptionMiddleware : IMiddleware
{
	async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
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

			errorResult.StatusCode = (int)GetErrorStatusCode(ex);

			HttpResponse response = context.Response;
			response.ContentType = "application/json";

			await response.WriteAsync(JsonSerializer.Serialize(errorResult));
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
				return HttpStatusCode.BadRequest;
			case UnauthorizedAccessException:
				return HttpStatusCode.Unauthorized;
			default:
				return HttpStatusCode.InternalServerError;
        }
	}
}
