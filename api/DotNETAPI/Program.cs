using System.Diagnostics;
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
var options = new DbContextOptionsBuilder<SqlContext>();
options.UseSqlServer(
    "Persist Security Info=False;User ID=formiga;Initial Catalog=AirlineApp;Server=localhost;Password=formiga123;TrustServerCertificate=True");
SqlContext context = new SqlContext(options.Options);
AviãoService aviãoService = new AviãoService(context);
UsuárioService us = new UsuárioService(context);
VooService vs = new VooService(context);
AssentoService assentoService = new AssentoService(context);
// aviãoService.AdicionarAvião("B738",28,6);
// vs.AdicionarVoo(4,7,1,"JJ5432",DateTime.Now.AddDays(1));
// us.AdicionarUsuário("Vinícius Formigone",18,2800);
// assentoService.ComprarAssento(1,"Vinícius Formigone",1,17,'A');
// assentoService.ComprarAssento(1,"Karina Sousa Costa",1,17,'B');
// us.ObterVoosAgendados(1);
app.Run("http://*:5000");