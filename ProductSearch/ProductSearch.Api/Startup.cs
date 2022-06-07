using System.Reflection;
using Microsoft.OpenApi.Models;
using ProductSearch.Application;
using ProductSearch.Application.Middlewares;
using ProductSearch.Application.Queries;
using ProductSearch.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductSearch.Api;

public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        Configuration = builder.Build();
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRouting(x => x.LowercaseUrls = true);

        services.AddInfrastructure(Configuration);
        services.AddApplication(Configuration);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "ProductSearch",
                    Version = "v1",
                    Description =
                        "Product search service"
                });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            var modelXmlFile = $"{Assembly.GetAssembly(typeof(FilterProductsQuery)).GetName().Name}.xml";
            var modelXmlPath = Path.Combine(AppContext.BaseDirectory, modelXmlFile);
            c.AddFluentValidationRulesScoped();
            c.UseInlineDefinitionsForEnums();
            c.IncludeXmlComments(xmlPath);
            c.IncludeXmlComments(modelXmlPath);
        });
        services.AddCors();
        services.AddMvcCore().AddApiExplorer();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(x => x
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowCredentials()
            .AllowAnyHeader());

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductSearch v1"));

        app.UseHttpsRedirection();

        app.UseRouting();
        
        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}