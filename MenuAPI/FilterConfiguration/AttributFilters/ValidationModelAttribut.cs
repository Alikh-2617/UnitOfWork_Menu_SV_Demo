using Microsoft.AspNetCore.Mvc.Filters;

namespace MenuAPI.FilterConfiguration.AttributFilters
{
    public class ValidationModelAttribut<T> : IActionFilter where T : class 
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
