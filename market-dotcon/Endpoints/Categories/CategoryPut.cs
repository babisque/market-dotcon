using market_dotcon.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace market_dotcon.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, CategoryRequest request, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null) return Results.NotFound();

        category.EditInfo(request.Name, request.Active);

        if (!category.IsValid)
            return Results.ValidationProblem(category.Notifications.ConvertToProblemDetails());

        context.SaveChanges();
        return Results.Ok();
    }
}
