using WebScrumBoard.Models;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<WebScrumBoardStorageInterface, WebScrumBoardStorage>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();