using Microsoft.AspNetCore.Mvc;

namespace Canteen.Models;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();
}
