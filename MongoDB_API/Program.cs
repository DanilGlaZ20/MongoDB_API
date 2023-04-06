using MongoDB_API.Models;
using MongoDB_API.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<BasketballDataBaseSettings>(
    builder.Configuration.GetSection("BasketballDatabase"));

builder.Services.AddSingleton<CoachService>();
builder.Services.AddSingleton<TeamService>();
builder.Services.AddSingleton<PlayerService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();