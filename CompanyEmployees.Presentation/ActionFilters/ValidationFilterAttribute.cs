namespace CompanyEmployees.Presentation.ActionFilters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ValidationFilterAttribute : IActionFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationFilterAttribute"/> class.
        /// </summary>
        public ValidationFilterAttribute()
        {

        }

        /// <summary>
        /// Called before the action executes, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;
            if (param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");

                return;
            }

            if (!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }

        /// <summary>
        /// Called after the action executes, before the action result.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
