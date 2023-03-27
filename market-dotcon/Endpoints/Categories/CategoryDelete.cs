using market_dotcon.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace market_dotcon.Endpoints.Categories;

public class CategoryDelete
{
    public static string Template => "/categories/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null) return Results.NotFound();

        category.EditInfo(false);

        if (!category.IsValid)
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());

        context.SaveChanges();

        return Results.NoContent();
    }
}
