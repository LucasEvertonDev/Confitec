using Microsoft.AspNetCore.Mvc.Filters;

namespace Confitec.Api.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
