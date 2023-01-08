namespace Canteen.Models;

public class FoodModel
{
    public Guid Id { get; }
    public string? Name { get; }
    public string? Description { get; }
    public int Price { get; }
    public int Stock { get; }
    public List<string>? Tags { get; }
    public string? ImageUrl { get; }
    public DateTime LastModifiedDateTime { get; }

    public FoodModel(Guid id, string? name, string? description, int price, int stock, List<string>? tags, string? imageUrl, DateTime lastModifiedDateTime)
    {
        // enforce invariants
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Tags = tags;
        ImageUrl = imageUrl;
        LastModifiedDateTime = lastModifiedDateTime;
    }
}
