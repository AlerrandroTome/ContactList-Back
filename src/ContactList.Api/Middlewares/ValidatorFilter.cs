using ContactList.Core.Dtos.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ContactList.Api.Middlewares
{
    public class ValidatorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Where(w => w.Value!.Errors.Count > 0)
                                              .Select(w => w.Value!.Errors.Select(w => w.ErrorMessage))
                                              .ToList();

                context.Result = new BadRequestObjectResult(new Response<string>
                {
                    StatusCode = 400,
                    AnErrorOcurred = true,
                    Data = null,
                    ErrorMessage = string.Concat(errors)
                });

                return;
            }

            await next();
        }
    }
}
