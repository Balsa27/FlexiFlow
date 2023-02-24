using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlexiFlow.Attribute;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class TokenAttribute : System.Attribute, IAuthorizationFilter 
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        object? user = context.HttpContext.Items["User"];
        
        if (user is null)
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) //change this to a custom exception that is handled in the global exception handler
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }
    }
}