using FlexiFlow.Attribute;
using FlexiFlow.Model.Request.User;
using FlexiFlow.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlexiFlow.Controller;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [AllowAnonymous]
    [HttpGet("id")]
    public ActionResult<User> GetUserById([FromBody] GetUserByIdRequest request) 
    {
        return Ok(_userService.GetById(request.id));
    }

    [HttpGet("all")]
    [TokenAttribute]
    public ActionResult<List<User>> GetAll()
    {
        return Ok(_userService.GetAll());
    }
}