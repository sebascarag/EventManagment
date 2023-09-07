using EventManagment.Api;
using EventManagment.Api.Middlewares;
using EventManagment.Application;
using EventManagment.DataAccess;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = builder.Configuration;
builder.Services.AddApi();
builder.Services.AddApplication();
builder.Services.AddDataAccess(config);

// Set Cors
builder.Services.AddCors(cors =>
    cors.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "EventManagmentApi", Version = "v2" });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    // Do migrations and initialize database when start app, if you don't want this approach, comment it
    await app.InitializeDatabaseAsync();

// Configure the HTTP request pipeline.

app.UseCors("CorsPolicy");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "EventManagmentApi");
});

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
