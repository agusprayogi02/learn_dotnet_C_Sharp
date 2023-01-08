namespace Canteen.Contacts.Food;

public record FoodResponse
(
    Guid Id,
    string Name,
    string Description,
    int Price,
    int Stock,
    List<string> Tags,
    string ImageUrl,
    DateTime LastModifiedDateTime
);
