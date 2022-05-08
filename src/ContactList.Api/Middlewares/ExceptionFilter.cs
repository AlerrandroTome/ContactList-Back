using ContactList.Core.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ContactList.Api.Middlewares
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new Response<string>
            {
                StatusCode = 400,
                AnErrorOcurred = true,
                Data = null,
                ErrorMessage = context.Exception.Message
            });

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
