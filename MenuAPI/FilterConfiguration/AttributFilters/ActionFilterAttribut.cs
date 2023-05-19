using DAL.AppDbContext;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MenuAPI.FilterConfiguration.AttributFilters
{
    public class ActionFilterAttribut : Attribute, IActionFilter
    {

        // this Filter can use for Actions and dont need to inject in program.cs 
        // we use it in Dinner Controller and som Action


        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Cheking Role or something");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Attribut Execut after Action");
        }
    }
}
