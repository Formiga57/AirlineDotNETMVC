using DefaultNamespace;
using DotNETAPI.Contexts;
using DotNETAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddDbContext<SqlContext>(opt =>
    opt.UseSqlServer(
        "Persist Security Info=False;User ID=formiga;Initial Catalog=AirlineApp;Server=localhost;Password=formiga123;TrustServerCertificate=True"));
builder.Services.AddScoped<ISqlRepo, SqlRepo>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();



app.Run();