using market_dotcon.Infra.Data;

namespace market_dotcon.Endpoints.Categories;

public class CategoryGetAllActive
{
    public static string Template => "/categories-active";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.Where(c => c.Active == true).ToList();

        if (categories.Count == 0) return Results.NotFound();

        var response = categories.Select(c => new CategoryResponse { Id = c.Id, Name = c.Name, Active = c.Active });

        return Results.Ok(response);
    }
}
