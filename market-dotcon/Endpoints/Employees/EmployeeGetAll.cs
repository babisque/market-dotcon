using market_dotcon.Infra.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace market_dotcon.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(int? page, int? rows, QueryAllUsersWithClaimName query)
    {
        if (page == null) page = 1;
        if (rows == null) rows = 5;
        if (rows > 10) return Results.BadRequest("You can only retrieve 10 rows per time.");

        return Results.Ok(query.Execute(page.Value, rows.Value));
    }
}