using FlexiFlow.Model.Request;
using FlexiFlow.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlexiFlow.Controller;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [AllowAnonymous]
    [HttpPost("login/user")]
    public ActionResult<UserLoginRequest> LoginUser([FromBody] UserLoginRequest request) 
    {
        return Ok(_authService.LoginUser(request));
    }
    
    [AllowAnonymous]
    [HttpPost("login/organization")]
    public ActionResult<OrganizationLoginRequest> LoginOrganization([FromBody] OrganizationLoginRequest request) 
    {
        return Ok(_authService.LoginOrganization(request));
    }
    
    [AllowAnonymous]
    [HttpPost("register/user")]
    public ActionResult<UserRegisterRequest> RegisterUser([FromBody] UserRegisterRequest request) 
    {
        return Ok(_authService.RegisterUser(request));
    }
    
    [AllowAnonymous]
    [HttpPost("register/organization")]
    public ActionResult<OrganizationRegisterRequest> RegisterOrganization([FromBody] OrganizationRegisterRequest request) 
    {
        return Ok(_authService.RegisterOrganization(request));
    }
}