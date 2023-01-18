namespace CompanyEmployees.Presentation.ActionFilters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Net.Http.Headers;

    public class ValidateMediaTypeAttribute : IActionFilter
    {
        /// <summary>
        /// Called before the action executes, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var acceptHeaderPresent = context.HttpContext.Request.Headers.ContainsKey("Accept");

            if (!acceptHeaderPresent)
            {
                context.Result = new BadRequestObjectResult($"Accept header is missing.");

                return;
            }

            var mediaType = context.HttpContext.Request.Headers["Accept"].FirstOrDefault();

            if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? outmediaType))
            {
                context.Result = new BadRequestObjectResult($"Media type not present. Please add Accept header with the required media type.");

                return;
            }

            context.HttpContext.Items.Add("AcceptHeaderMediaType", outmediaType);
        }

        /// <summary>
        /// Called after the action executes, before the action result.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
