using Microsoft.AspNetCore.Mvc.Filters;
using SmartManagerServer.Infrastructure.Services.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.EndPointExtensions.ApiAttributeFilters
{
    public class UserResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var httpContextService = (HttpContextService)context.HttpContext.RequestServices.GetService(typeof(HttpContextService));
            await httpContextService.AddUserDataAsync(context.HttpContext);
            await next();
        }
    }
}
