using Case.SoftGenius.Api.Application.Countries.CreateCountry;
using Case.SoftGenius.Api.Application.Countries.GetCountries;
using Case.SoftGenius.Api.Application.Countries.SetCountryAsInactive;
using Case.SoftGenius.Api.Application.Countries.UpdateCountry;
using Case.SoftGenius.Api.Application.Users.ChangeCountryOfUser;
using Case.SoftGenius.Api.Application.Users.CreateUser;
using Case.SoftGenius.Api.Application.Users.DeleteUser;
using Case.SoftGenius.Api.Application.Users.GetUser;
using Case.SoftGenius.Api.Application.Users.GetUsers;
using Case.SoftGenius.Api.Application.Users.UpdateUser;
using Case.SoftGenius.Api.Infrastructure;
using Case.SoftGenius.Api.Presentation.Filters;
using Case.SoftGenius.Api.Presentation.Middlewares;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCountryCommand))); builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddInfrastructureServices();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCountryCommand>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
    app.UseExceptionHandler("/Error");
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

var countriesGroup = app.MapGroup("").WithTags("Countries").WithOpenApi();

countriesGroup.MapGet("countries", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetCountriesQuery());
    return Results.Ok(result);
}).WithName("GetCountries");

countriesGroup.MapPost("/countries", async (CreateCountryCommand request, IMediator mediator) =>
{
    var result = await mediator.Send(request);
    return Results.Created("", result);
}).WithName("CreateCountry")
.AddEndpointFilter<ValidationFilter<CreateCountryCommand>>();

countriesGroup.MapPut("/countries", async (UpdateCountryCommand request, IMediator mediator) =>
{
    var result = await mediator.Send(request);
    if (result)
    {
        return Results.NoContent();
    }
    return Results.NotFound();

}).WithName("UpdateCountry")
.AddEndpointFilter<ValidationFilter<UpdateCountryCommand>>();

countriesGroup.MapPut("countries/set-inactive/{id}", async (uint id, IMediator mediator) =>
{
    var result = await mediator.Send(new SetCountryAsInactiveCommand(id));
    if (!result)
    {
        return Results.NotFound();
    }
    return Results.NoContent();
}).WithName("SetCountryAsInactive");

var usersGroup = app.MapGroup("").WithTags("Users").WithOpenApi();

usersGroup.MapPost("/users", async (CreateUserCommand request, IMediator mediator) =>
{
    var result = await mediator.Send(request);
    return Results.Created("", result);
}).WithName("CreateUser")
.AddEndpointFilter<ValidationFilter<CreateUserCommand>>();

usersGroup.MapGet("/users", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetUsersQuery());
    return Results.Ok(result);
}).WithName("GetUsers");

usersGroup.MapGet("/users/{id}", async (uint id, IMediator mediator) =>
{
    var result = await mediator.Send(new GetUserQuery(id));
    if (result is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(result);
}).WithName("GetUser");

usersGroup.MapPut("/users", async (UpdateUserCommand request, IMediator mediator) =>
{
    var result = await mediator.Send(request);
    if (!result)
    {
        return Results.NotFound();
    }
    return Results.NoContent();
}).WithName("UpdateUser");

usersGroup.MapPut("/users/change-country", async (ChangeCountryOfUserCommand request, IMediator mediator) =>
{
    var result = await mediator.Send(request);
    if (!result)
    {
        return Results.NotFound();
    }
    return Results.NoContent();
}).WithName("ChangeCountry");

usersGroup.MapDelete("/users/{id}", async (uint id, IMediator mediator) =>
{
    var result = await mediator.Send(new DeleteUserCommand(id));
    if (!result)
    {
        return Results.NotFound();
    }
    return Results.NoContent();
}).WithName("DeleteUser");


app.Run();
