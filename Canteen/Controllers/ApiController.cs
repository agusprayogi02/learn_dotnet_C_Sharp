using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    public IActionResult Problem(List<Error> errors)
    {
        var firsError = errors[0];
        var statusCode = firsError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Failure => StatusCodes.Status403Forbidden,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };
        return Problem(
            statusCode: statusCode,
            title: firsError.Description
        );
    }
}
