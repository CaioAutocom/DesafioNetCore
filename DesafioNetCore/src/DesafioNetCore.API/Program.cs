using DesafioNetCore.API;
using DesafioNetCore.Application;
using DesafioNetCore.Infra;
using DesafioNetCore.Infra.Repository;
using DesafioNetCore.Infra.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

// Lembrar de resolver as dependencias de um jeito mais profissional
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<DesafioNetCore.Application.Contracts.IProductService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Utilizando o Identity para autenticar
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
