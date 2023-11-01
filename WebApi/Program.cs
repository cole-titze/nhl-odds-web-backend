using DataAccess.GameOddsRepository;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.GameOddsGetter;
using BusinessLogic.TeamGetter;
using DataAccess.TeamRepository;
using DataAccess.LogLossRepository;
using BusinessLogic.LogLossGetter;

var builder = WebApplication.CreateBuilder(args);

string? _connectionString = Environment.GetEnvironmentVariable("NHL_DATABASE");
if (_connectionString == null)
{
    var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
    _connectionString = config.GetConnectionString("NHL_DATABASE");
}
if (_connectionString == null)
    throw new Exception("Connection String Null");

// Add services to the container
builder.Services.AddScoped<ITeamGetter, TeamGetter>();
builder.Services.AddScoped<IGameOddsGetter, GameOddsGetter>();
builder.Services.AddScoped<ILogLossRepository, LogLossRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IGameOddsRepository, GameOddsRepository>();
builder.Services.AddScoped<ILogLossGetter, LogLossGetter>();
builder.Services.AddDbContext<GameDbContext>(x => x.UseSqlServer(_connectionString));
builder.Services.AddLogging();

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
                          builder.WithOrigins("http://10.0.0.19:8081");
                          builder.WithOrigins("http://192.168.1.19:8081");
                          builder.WithOrigins("http://localhost:8081");
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

