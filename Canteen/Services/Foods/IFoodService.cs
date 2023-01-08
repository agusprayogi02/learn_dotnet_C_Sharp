using Canteen.Contacts.Food;
using Canteen.Models;
using ErrorOr;

namespace Canteen.Services.Foods;

public interface IFoodService
{
    void DeleteFood(Guid id);
    ErrorOr<FoodModel> GetFood(Guid id);
    FoodResponse InsertFood(FoodModel food);
    void UpdateFood(Guid id, FoodModel model);
}
