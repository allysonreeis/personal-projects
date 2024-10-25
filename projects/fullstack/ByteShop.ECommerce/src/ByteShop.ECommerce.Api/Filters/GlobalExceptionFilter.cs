using ByteShop.ECommerce.Api.Shared;
using ByteShop.ECommerce.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ByteShop.ECommerce.Api.Filters;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is DomainValidationException domainValidationException)
        {
            context.Result = new ObjectResult(new { domainValidationException.Errors })
            {
                StatusCode = 400,
            };
            context.ExceptionHandled = true;
        }
        else
        {
            context.Result = new ObjectResult(new { errors = context.Exception.Message })
            {
                StatusCode = 500,
            };
        }
    }
}
