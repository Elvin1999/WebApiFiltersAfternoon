using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiFilters.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        private readonly ILogger<CustomActionFilter> _logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var queryParams = context.HttpContext.Request.Query;
            var routeParams = context.RouteData.Values;

            _logger.LogInformation($"Query Parameters : {queryParams}");
            _logger.LogInformation($"Route Parameters : {routeParams}");

            if (!queryParams.ContainsKey("name"))
            {
                context.Result = new BadRequestObjectResult("Missing required name query param");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"OnActionExecuted : Executed action method");
        }

    }
}
