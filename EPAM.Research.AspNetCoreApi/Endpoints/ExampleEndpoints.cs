using System.IO;
using System.Text;
using System.Text.Json;
using EPAM.Research.AspNetCoreApi.Models;
using EPAM.Research.AspNetCoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Ramboe.MinimalApis;

namespace EPAM.Research.AspNetCoreApi.Endpoints;

public class ExampleEndpoints : IEndpoints
{
    public static void DefineEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/requests", AllTheRequests);
        app.MapGet("/", () => "I should call you sugar because you are so sweet.");
        app.MapGet("/stuff", doStuff);
        app.MapPost("/", postStuff);
    }

    public static List<string> AllTheRequests(RequestCounter counter)
    {
        return counter.Posts;
    }

    public static void AddServices(IServiceCollection services, IConfiguration configuration, bool isDev)
    {
        //services that these endpoints require
    }

    async static Task<IResult> postStuff(HttpContext context, RequestCounter requestCounter, PostModel model)
    {
        https://markb.uk/asp-net-core-read-raw-request-body-as-string.html
        context.Request.EnableBuffering();

        using var reader = new StreamReader(context.Request.Body);
        var body = await reader.ReadToEndAsync();

        context.Request.Body.Position = 0;

        using var reader2 = new StreamReader(context.Request.Body);

        var secondString = await reader2.ReadToEndAsync();

        var item = body + ", " + secondString.Length;
        requestCounter.Posts.Add(item);
        
        context.Request.Body.Position = 0;

        return Results.Created("/", item);
    }

    static async Task<IResult> doStuff(HttpContext context)
    {
        using var reader = new StreamReader(context.Request.Body);
        var body = await reader.ReadToEndAsync();

        return Results.Ok(body);
    }
}
