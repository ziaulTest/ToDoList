﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDoList.Filters
{
    public class ValidateModelFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next.Invoke();
            }
        }
    }
}
