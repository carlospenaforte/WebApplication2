
namespace WebApplication2.Endpoints;

public static class AppsEndpoints
{
    const string GetAppEndpointName = "GetApp";

    private static readonly List<AppDTO> apps = [
        new (
        1,
        "App1",
        "Music",
        9.90,
        new DateOnly(2005, 4, 20)),
    new (
        2,
        "App2",
        "News",
        2.99,
        new DateOnly(1999, 11, 25)),
    new(
        3,
        "App3",
        "Blog",
        0.00,
        new DateOnly(2000, 3, 12))
    ];

    public static RouteGroupBuilder MapAppsEndpoints(this WebApplication2 app)
    {
        var group = app.MapGroup("apps");

        // GET /apps
        group.MapGet("/", () => apps);

        // GET /apps/1
        group.MapGet("/{Id}", (int Id) =>
        {
            AppDTO? apps = apps.Find(app => app.Id == Id);

            return app is null ? Results.NotFound() : Results.Ok(app);
        })
        .WithName(GetAppEndpointName);


        // POST /apps
        group.MapPost("/", (CreateAppDTO newApp) =>
        {
            AppDTO app = new(
                apps.Count + 1,
                newApp.Name,
                newApp.Genre,
                newApp.Price,
                newApp.ReleaseDate);

            apps.Add(app);

            return Results.CreatedAtRoute(GetAppEndpointName, new { Id = app.Id }, app);
        });

        // PUT / APPS
        group.MapPut("/{Id}", (int Id, UpdateAppDTO updatedApp) =>
        {
            var index = apps.FindIndex(app => app.Id == Id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            apps[index] = new AppDTO(
                Id,
                updatedApp.Name,
                updatedApp.Genre,
                updatedApp.Price,
                updatedApp.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE /GAMES/1
        group.MapDelete("/{Id}", (int Id) =>
        {
            apps.RemoveAll(apps => app.Id == Id);

            return Results.NoContent();
        });

        return group;
    }
}