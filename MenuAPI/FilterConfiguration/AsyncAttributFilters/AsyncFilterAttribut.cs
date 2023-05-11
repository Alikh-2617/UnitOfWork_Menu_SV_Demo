using Microsoft.AspNetCore.Mvc.Filters;

namespace MenuAPI.FilterConfiguration.AsyncAttributFilters
{
    public class AsyncFilterAttribut : Attribute, IAsyncActionFilter
    {
        private readonly string _DbContext;
        public AsyncFilterAttribut(string context)
        {
            _DbContext = context;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Execution");
            // befor
            // daligate next ! 
            await next.Invoke();
            // efter Execution
        }
    }
}
