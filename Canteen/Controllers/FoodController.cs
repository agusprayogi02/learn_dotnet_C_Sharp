using Canteen.Contacts.Food;
using Canteen.Models;
using Canteen.Services.Foods;
using Canteen.ServicesErrors;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [HttpPost]
    public IActionResult InsertFood([FromBody] InsertFoodRequest request)
    {
        var model = new FoodModel(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.Price,
            request.Stock,
            request.Tags,
            request.ImageUrl,
            DateTime.UtcNow
        );
        // TODO: have save to database
        var response = _foodService.InsertFood(model);

        return CreatedAtAction(nameof(GetFood), new { id = response.Id }, response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetFood(Guid id)
    {
        var getFoodResult = _foodService.GetFood(id);
        if (getFoodResult.IsError && getFoodResult.FirstError == Errors.Food.NotFound)
        {
            return NotFound();
        }
        var model = getFoodResult.Value;
        var response = new FoodResponse(
            model.Id,
            model.Name ?? "",
            model.Description ?? "",
            model.Price,
            model.Stock,
            model.Tags ?? new List<string>(),
            model.ImageUrl ?? "",
            model.LastModifiedDateTime
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateFood(Guid id, [FromBody] UpsertFoodRequest request)
    {
        var model = new FoodModel(
            id,
            request.Name,
            request.Description,
            request.Price,
            request.Stock,
            request.Tags,
            request.ImageUrl,
            DateTime.UtcNow
        );
        _foodService.UpdateFood(id, model);

        // TODO: return 201 if created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteFood(Guid id)
    {
        _foodService.DeleteFood(id);
        return NoContent();
    }
}
