
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Logging;
using NewsService.Interfaces;
using NewsService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.RequestProperties;
});

builder.Services.AddSingleton<ITempService, TempService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseHttpLogging();
}

app.MapGet("/", () => "Hello World!");
app.MapGet("/temp-content", (ITempService temService) =>  temService.CreateTempContent() );
app.MapGet("/news", () => new List<News>() { new("Title1", "Content1" ), new( "Title2", "Content2") });

app.Run();


public record News(string Title, string Content);