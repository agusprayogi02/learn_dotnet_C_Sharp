using Canteen.Models;
using Canteen.ServicesErrors;
using ErrorOr;

namespace Canteen.Services.Foods;

public class FoodService : IFoodService
{
    private static readonly Dictionary<Guid, FoodModel> _foods = new();

    public ErrorOr<Deleted> DeleteFood(Guid id)
    {
        _foods.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<FoodModel> GetFood(Guid id)
    {
        if (_foods.TryGetValue(id, out var food))
        {
            return food;
        }
        return Errors.Food.NotFound;
    }

    public ErrorOr<Created> InsertFood(FoodModel food)
    {
        _foods.Add(food.Id, food);

        return Result.Created;
    }

    public ErrorOr<UpsertedFood> UpdateFood(Guid id, FoodModel model)
    {
        var IsNewlyCreated = !_foods.ContainsKey(id);
        _foods[id] = model;
        return new UpsertedFood(IsNewlyCreated);
    }
}
