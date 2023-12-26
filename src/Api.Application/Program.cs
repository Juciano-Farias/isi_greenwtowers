using Api.CrossCutting.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "API para a aplicação Green Towers.",
    Description = "O projeto Green Towers surge pela necessidade de uma aplicação que centralize a comunicação, necessidades e agendamentos entre os condôminos e o administrador do condomínio. Esta API servirá para o mencionado propósito.",
    TermsOfService = new Uri("https://github.com/Juciano-Farias"),
    Contact = new OpenApiContact
    {
        Name = "Juciano Gomes Farias Junior",
        Email = "jucianogfjr@gmail.com",
        Url = new Uri("https://jucianofarias.vercel.app/"),
    },
    License = new OpenApiLicense
    {
        Name = "Termo de Licença de Uso",
        Url = new Uri("https://github.com/Juciano-Farias")
    }
}));

ConfigureService.ConfigureDependenciesService(builder.Services);
ConfigureRepository.ConfigureDependenciesRepository(builder.Services);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API para a aplicação Green Towers.");
        c.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();