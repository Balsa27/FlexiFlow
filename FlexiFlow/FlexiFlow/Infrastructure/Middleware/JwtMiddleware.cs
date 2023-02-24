using System.Security.Authentication;
using FlexiFlow.Service;

namespace FlexiFlow.Infrastructure.Jwt;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
       
        var userId = jwtUtils.ValidateToken(token);
        
        if (userId != null)
        {
            context.Items["User"] = userService.GetById(userId.Value);
            //context.Items["id"] = userId;
        }

        await _next(context);
    }
}
