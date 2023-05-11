using Microsoft.AspNetCore.Mvc.Filters;

namespace MenuAPI.FilterConfiguration.AttributFilters
{
    public class ActionFilterAttribut : Attribute, IActionFilter
    {
        // this Filter can use for Actions and dont need to inject in program.cs 
        // we use it in Dinner Controller and som Action
        private readonly string _somting;

        public ActionFilterAttribut(string ss)
        {
            _somting = ss;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Attribut Execut before Action");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Attribut Execut after Action");
        }
    }
}
