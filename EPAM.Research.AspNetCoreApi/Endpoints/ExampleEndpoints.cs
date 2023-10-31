using System.Text.Json;
using EPAM.Research.AspNetCoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using Ramboe.MinimalApis;

namespace EPAM.Research.AspNetCoreApi.Endpoints;

public class ExampleEndpoints : IEndpoints
{
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "I should call you sugar because you are so sweet.");
        app.MapGet("/stuff", doStuff);
        app.MapPost("/", postStuff);
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration, bool isDev)
    {
        //services that these endpoints require
    }

    static IResult postStuff(HttpContext context, [FromBody] PostModel model)
    {
        var modelAsString = JsonSerializer.Serialize(model);

        return Results.Ok(modelAsString);
    }

    static IResult doStuff(HttpContext context)
    {
        var body = context.Request.Body.ToString();

        return Results.Ok(body);
    }
}
