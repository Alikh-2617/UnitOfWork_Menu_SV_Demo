using DAL.AppDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MenuAPI.FilterConfiguration.GlobalFilters
{
    public class GlobalFilter : IActionFilter
    {
        // this filter have to inject in program.cs in Add.Controller  and didnt writh över controller or Actions . Just it

        List<string> ips = new List<string>();
        private int visitur = 0;   // den kan lagera i ett static file !!

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var clientIp = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            var clientLocalIp = context.HttpContext.Connection.LocalIpAddress?.ToString() ?? string.Empty;
            var locaPort = context.HttpContext.Connection.LocalPort.ToString();

            ips.Add($"IP : {clientIp}>> Local Ip = {clientLocalIp} >> Local port : {locaPort}");
            //context.Result = new BadRequestObjectResult($"ip = {clientIp} : Local Ip = {clientLocalIp}: port = {locaPort} ");
            //return;

            //if(visitur >= 100)
            //{
            //    context.Result = new BadRequestObjectResult("Its to much visitur visiting the site , you can try again about 10 minutes ! ");
            //    return;
            //}
            //visitur++;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //visitur--;
        }
    }
}
