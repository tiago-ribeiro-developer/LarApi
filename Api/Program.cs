using System.Reflection;
using Application;
using Domain;
using Domain.Common;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários
builder.Services.AddControllers();

// Habilita a documentação Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Caminho para o arquivo XML gerado, o que normalmente será no diretório de saída bin
    var xmlFile = $"{AppDomain.CurrentDomain.FriendlyName}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API para teste LAR",
        Version = "v1",
        Description = "Uma API para gerenciar de pessoas com relacionamento de telefone."
    });
});

builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddInfraRepositoryServices();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("LAR_DB"));

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
