using WebApplication2.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = "Data Source=AppStore.db";
builder.Services.AddSqlite<AppStoreContext>(connString);

var app = builder.Build();

app.MapAppsEndpoints();

app.Run();
