﻿using market_dotcon.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace market_dotcon.Endpoints.Categories;

public class CategoryGetById
{
    public static string Template => "/categories/{id:int}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action([FromRoute] int id, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null) return Results.NotFound();

        var response = new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Active = category.Active,
        };

        return Results.Ok(response);
    }
}
