using DesafioNetCore.API;
using DesafioNetCore.Application;
using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.CQRS;
using DesafioNetCore.Application.Services;
using DesafioNetCore.Infra;
using DesafioNetCore.Infra.Migrations;
using DesafioNetCore.Infra.Repository;
using DesafioNetCore.Infra.Repository.Contracts;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
// Lembrar de resolver as dependencias de um jeito mais profissional
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUnitService, UnitService>();


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

DbMigrationHelpers.EnsureSeedData(app).Wait();

app.Run();
