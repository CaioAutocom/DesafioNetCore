using DesafioNetCore.API;
using DesafioNetCore.Application;
using DesafioNetCore.Infra;
using DesafioNetCore.Infra.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
//teste liberar comunicação com o front
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(["http://localhost:5440/"]);
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();
        policy.SetIsOriginAllowed(_ => true);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
// foi recomendado desabilitar o httpsredirection para evitar bug, isso na video aula do clone do whatsapp
//app.UseHttpsRedirection();
// Utilizando o Identity para autenticar
app.UseAuthentication();
app.UseAuthorization();
// resolvendo a dependencia do meu middleware de exceção
app.UseExceptionMiddleware();

app.MapControllers();

DbMigrationHelpers.EnsureSeedData(app).Wait();

app.Run();
