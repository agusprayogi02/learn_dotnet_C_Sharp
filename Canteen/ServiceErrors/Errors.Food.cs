using ErrorOr;

namespace Canteen.ServicesErrors;

public static class Errors
{
    public static class Food
    {
        public static Error NotFound => Error.NotFound("Food.NotFound", "Food not found");
    }
}
