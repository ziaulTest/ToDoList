using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDoList.Filters
{
    public class ValidateModelFilter : IAsyncActionFilter
    {
        //private readonly MetricsTracker MetricsTracker;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next.Invoke();
                return;
            }
            var errors = context.ModelState;
            context.Result = new BadRequestObjectResult(errors);
           // MetricsTracker.TrackTrace(errors.ToString());
        }
    }
}
