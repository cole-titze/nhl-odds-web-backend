using DataAccess.PredictedGameRepository;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.LogLoss;
using BusinessLogic.PredictedGameGetter;
using BusinessLogic.Betting;

var builder = WebApplication.CreateBuilder(args);

string? _connectionString = Environment.GetEnvironmentVariable("PREDICTED_GAME_DATABASE");
if (_connectionString == null)
    _connectionString = builder.Configuration.GetConnectionString("PREDICTED_GAME_DATABASE");
if (_connectionString == null)
    throw new Exception("Connection String Null");

// Add services to the container.
builder.Services.AddScoped<ILogLossCalculator, LogLossCalculator>();
builder.Services.AddScoped<IPredictedGameGetter, PredictedGameGetter>();
builder.Services.AddScoped<IBettingCalculator, BettingCalculator>();
builder.Services.AddScoped<IPredictedGameRepository, PredictedGameRepository>();
builder.Services.AddDbContext<PredictedGameDbContext>(x => x.UseSqlServer(_connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:8081");
                          builder.WithOrigins("https://gray-bush-0811f9c10.1.azurestaticapps.net/");
                      });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

