using Canteen.Contacts.Food;
using Canteen.Models;

namespace Canteen.Services.Foods;

public interface IFoodService
{
    void DeleteFood(Guid id);
    FoodModel GetFood(Guid id);
    FoodResponse InsertFood(FoodModel food);
    void UpdateFood(Guid id, FoodModel model);
}
