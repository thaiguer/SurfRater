using SurfRater.WebApi.Common;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Queijo!");
app.MapGet("/health", () => Health.GetHealthMessageApi());

app.Run();