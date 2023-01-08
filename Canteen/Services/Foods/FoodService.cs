using Canteen.Contacts.Food;
using Canteen.Models;

namespace Canteen.Services.Foods;

public class FoodService : IFoodService
{
    private static readonly Dictionary<Guid, FoodModel> _foods = new();

    public void DeleteFood(Guid id)
    {
        _foods.Remove(id);
    }

    public FoodModel GetFood(Guid id)
    {
        return _foods[id];
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
