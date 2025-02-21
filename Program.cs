using WebApplication2;
using WebApplication2.DTOs;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

app.MapGet("apps/{Id}", (int Id) => 
    apps.Find(app => app.Id == Id) ?? Results.NotFound($"App com ID {Id} não encontrado"));

app.Run();
