using System.Reflection.Metadata.Ecma335;
using WebApplication2;
using WebApplication2.DTOs;
using WebApplication2.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapAppsEndpoints();

app.Run();
