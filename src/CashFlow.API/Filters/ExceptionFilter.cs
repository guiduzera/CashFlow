using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CashFlowException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if (context.Exception is ErrorValidationException)
        {
            var ex = (ErrorValidationException)context.Exception;

            var errorResponse = new ResponseError(ex.ErrorMessages);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            context.Result = new BadRequestObjectResult(errorResponse);
        }
        else
        {
            var response = new ResponseError(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            context.Result = new BadRequestObjectResult(response);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
       var response = new ResponseError("Unknow Error!");

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Result = new ObjectResult(response);
    }
}

