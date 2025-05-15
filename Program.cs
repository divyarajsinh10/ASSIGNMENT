using SimpleApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.UseAuthMiddleware(); // Register custom auth middleware
app.MapControllers();
app.Run();
