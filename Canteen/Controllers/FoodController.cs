using Canteen.Contacts.Food;
using Canteen.Models;
using Canteen.Services.Foods;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.Controllers;

public class FoodController : ApiController
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
        var getResult = _foodService.InsertFood(model);
        return getResult.Match(
            insert => mapperCreated(model),
            errs => Problem(errs)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetFood(Guid id)
    {
        return _foodService.GetFood(id)
            .Match<IActionResult>(
                food => Ok(mapperResponse(food)),
                errs => Problem(errs)
            );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertFood(Guid id, [FromBody] UpsertFoodRequest request)
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
        var restUp = _foodService.UpdateFood(id, model);
        return restUp.Match(
            up => up.IsNewlyCreated ? mapperCreated(model) : NoContent(),
            errs => Problem(errs)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteFood(Guid id)
    {
        var rest = _foodService.DeleteFood(id);
        return rest.Match(
            delet => NoContent(),
            errs => Problem(errs)
        );
    }

    public static FoodResponse mapperResponse(FoodModel food)
    {
        return new FoodResponse(
            food.Id,
            food.Name ?? "",
            food.Description ?? "",
            food.Price,
            food.Stock,
            food.Tags ?? new List<string>(),
            food.ImageUrl ?? "",
            food.LastModifiedDateTime
        );
    }

    private CreatedAtActionResult mapperCreated(FoodModel model)
    {
        return CreatedAtAction(nameof(GetFood), new { id = model.Id }, mapperResponse(model));
    }
}
