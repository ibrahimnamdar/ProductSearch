using Microsoft.EntityFrameworkCore;
using ProductSearch.Api;
using ProductSearch.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

var startup = new Startup(builder.Configuration, environment);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<ProductSearchDbContext>();
    context.Database.Migrate();
    Seed.Run(context);
}

startup.Configure(app, app.Environment, app.Lifetime);

app.Run();
