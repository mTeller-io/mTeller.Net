var builder = WebApplication.CreateBuilder(args);

// Add services here
builder.Services.AddIdentityServer();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Add middleware stuff
app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();