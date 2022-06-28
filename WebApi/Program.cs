using DataAccess.PredictedGameRepository;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string _connectionString = builder.Configuration.GetConnectionString("PredictedGameDatabase");

// Add services to the container.
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

