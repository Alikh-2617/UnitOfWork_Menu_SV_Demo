using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Drawing;
using System.Linq;

namespace MenuAPI.FilterConfiguration.AttributFilters
{
    public class FileValidationAttribut : IActionFilter
    {
        private string[] allowForm = {"image/png", "image/jpeg" , "image/gif" };


        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey("file"))
            {
                context.Result = new BadRequestObjectResult("Not allow file !");
                return;
            }
            // try to validate the file is image from context ! 
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
