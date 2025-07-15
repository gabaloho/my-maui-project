using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoDbSetting = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDBSettings>();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDbSettings"));
if (mongoDbSetting == null)
{
  throw new InvalidOperationException("MongoDbSettings section is missing or invalid in configuration.");
}
builder.Services.AddDbContext<ContosoPizzaDbContext>(options =>
    options.UseMongoDB(mongoDbSetting.ConnectionString ?? "", mongoDbSetting.DatabaseName ?? ""));

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "ContosoPizza API",
    Version = "v1"
  });
  c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Description = "Please insert JWT with Bearer into field",
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey
  });
  c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      Array.Empty<string>()
                    }
                  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger(c =>
  {
    c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
  });

  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContosoPizza API V1");
    c.RoutePrefix = string.Empty; // This sets Swagger UI as the homepage
  });

  app.MapOpenApi(); // Optional if you use NSwag; not needed for Swashbuckle
  app.MapSwagger(); // Optional unless you're using minimal APIs
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
