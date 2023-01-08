using Canteen.Models;
using ErrorOr;

namespace Canteen.Services.Foods;

public interface IFoodService
{
    ErrorOr<Deleted> DeleteFood(Guid id);
    ErrorOr<FoodModel> GetFood(Guid id);
    ErrorOr<Created> InsertFood(FoodModel food);
    ErrorOr<UpsertedFood> UpdateFood(Guid id, FoodModel model);
}
