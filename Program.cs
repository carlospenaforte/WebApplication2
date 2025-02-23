using WebApplication2;
using WebApplication2.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetAppEndpointName = "GetApp";

List<AppDTO> apps = [
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

// GET /apps
app.MapGet("apps", () => apps);

// GET /apps/1
app.MapGet("apps/{Id}", (int Id) => apps.Find(app => app.Id == Id))
    .WithName(GetAppEndpointName);


// POST /apps
app.MapPost("apps", (CreateAppDTO newApp) =>
{
    AppDTO app = new(
        apps.Count + 1,
        newApp.Name,
        newApp.Genre,
        newApp.Price,
        newApp.ReleaseDate);

    apps.Add(app);

    return Results.CreatedAtRoute(GetAppEndpointName, new {Id = app.Id}, app);
});


app.Run();
