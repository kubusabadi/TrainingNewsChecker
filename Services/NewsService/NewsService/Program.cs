
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NewsService.Interfaces;
using NewsService.Services;
using System;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.RequestProperties;
});

builder.Services.AddSingleton<ITempService, TempService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NewsService API",
        Description = "Collecting news from external APIs",
        Version = "v1"
    });
});

builder.Services.AddDbContext<NewsServiceDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewsConnectionString")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseHttpLogging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewsService API V1");
    });
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/temp-content", (ITempService temService) =>  temService.CreateTempContent() );
app.MapGet("/news", () => new List<News>() { new("Title1", "Content1" ), new( "Title2", "Content2") });
app.MapGet("/visits", async (NewsServiceDb db) => await db.Visits.ToListAsync());
app.Run();


public record News(string Title, string Content);