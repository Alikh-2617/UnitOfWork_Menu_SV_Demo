﻿using DAL.AppDbContext;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace MenuAPI.FilterConfiguration.AttributFilters
{
    public class ValidationActionFilterAttribut<T> :IActionFilter where T : class 
    {
        private readonly ApplicationDbContext _context;

        public ValidationActionFilterAttribut(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = Guid.Empty;
            if (context.ActionArguments.ContainsKey("id"))
            {
                id = (Guid)context.ActionArguments["id"]!;
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad id prameter");
                return;
            }
            var input = _context.Set<T>().Find(id);
            if (input == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("entity", input);
            }

            //var ss = context.ActionArguments.FirstOrDefault().Value;
            //context.Result = new BadRequestObjectResult($"{ss} :  ");
            //return;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
