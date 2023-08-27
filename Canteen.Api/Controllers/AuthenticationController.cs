using Canteen.Application.Services;
using Canteen.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _service;

    public AuthenticationController(IAuthenticationService service)
    {
        this._service = service;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest req)
    {
        var result = _service.Register(
            req.FistName,
            req.LastName,
            req.Email,
            req.Password
        );
        var response = new AuthenticationResponse(
            result.id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest req)
    {
        var rest = _service.Login(req.Email, req.Password);
        var response = new AuthenticationResponse(
            rest.id,
            rest.FirstName,
            rest.LastName,
            rest.Email,
            rest.Token
            );
        return Ok(response);
    }
}