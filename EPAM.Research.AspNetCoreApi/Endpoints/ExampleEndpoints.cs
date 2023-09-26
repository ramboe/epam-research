using Ramboe.MinimalApis;

namespace EPAM.Research.AspNetCoreApi.Endpoints;

public class ExampleEndpoints : IEndpoints
    {
        public static void DefineEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/", () => "is that enough?");
            app.MapGet("/stuff", doStuff);
        }

        public static void AddServices(IServiceCollection services, IConfiguration configuration, bool isDev)
        {
            //services that these endpoints require
        }

        static IResult doStuff(HttpContext context)
        {
            var body = context.Request.Body.ToString();


            return Results.Ok(body);
        }
    }
