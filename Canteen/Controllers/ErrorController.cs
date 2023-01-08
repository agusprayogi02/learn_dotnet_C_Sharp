using Microsoft.AspNetCore.Mvc;

namespace Canteen.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();
}
