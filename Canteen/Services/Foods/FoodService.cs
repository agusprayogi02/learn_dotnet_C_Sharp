using Canteen.Contacts.Food;
using Canteen.Models;
using Canteen.ServicesErrors;
using ErrorOr;

namespace Canteen.Services.Foods;

public class FoodService : IFoodService
{
    private static readonly Dictionary<Guid, FoodModel> _foods = new();

    public void DeleteFood(Guid id)
    {
        _foods.Remove(id);
    }

    public ErrorOr<FoodModel> GetFood(Guid id)
    {
        if (_foods.TryGetValue(id, out var food))
        {
            return food;
        }
        return Errors.Food.NotFound;
    }

    public FoodResponse InsertFood(FoodModel food)
    {
        _foods.Add(food.Id, food);
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

    public void UpdateFood(Guid id, FoodModel model)
    {
        _foods[id] = model;
    }
}
