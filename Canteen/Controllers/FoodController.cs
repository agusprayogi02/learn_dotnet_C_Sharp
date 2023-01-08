using Canteen.Contacts.Food;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    [HttpPost]
    public IActionResult InsertFood([FromBody] InsertFoodRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/{id:guid}")]
    public IActionResult GetFood(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/{id:guid}")]
    public IActionResult UpdateFood(Guid id, [FromBody] UpsertFoodRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/{id:guid}")]
    public IActionResult DeleteFood(Guid id)
    {
        return Ok(id);
    }
}
