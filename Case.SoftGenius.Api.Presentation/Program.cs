using Case.SoftGenius.Api.Application.Countries.CreateCountry;
using Case.SoftGenius.Api.Domain.Entities;
using Case.SoftGenius.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCountryCommand)));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddInfrastructureServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/countries", (IMediator mediator, CreateCountryCommand request) =>
{
    var result = mediator.Send(request);
    return result;
}).WithName("CreateCountry")
.WithOpenApi();

app.MapGet("/countries", () =>
{
    var countries = new List<Country>
    {
        new() { Id = 1, Name = "Australia" },
        new() { Id = 2, Name = "Austria" },
        new() { Id = 3, Name = "Belgium" }
    };
    return countries;
}).WithName("GetCountries")
.WithOpenApi();

app.Run();
