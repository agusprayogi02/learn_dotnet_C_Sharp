namespace Canteen.Contacts.Food;

public record InsertFoodRequest(
    string Name,
    string Description,
    int Price,
    int Stock,
    List<string> Tags,
    string ImageUrl
);
