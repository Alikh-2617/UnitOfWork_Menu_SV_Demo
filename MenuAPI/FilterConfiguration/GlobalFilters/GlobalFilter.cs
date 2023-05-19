using DAL.AppDbContext;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MenuAPI.FilterConfiguration.GlobalFilters
{
    public class GlobalFilter : IActionFilter
    {
        // this filter have to inject in program.cs in Add.Controller  and didnt writh över controller or Actions . Just it

        // before Action Or Controller Executing
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("chekede cleam or something els");
        }

        // after Action Or Controller Executing
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Before Action executing");
        }
    }
}
