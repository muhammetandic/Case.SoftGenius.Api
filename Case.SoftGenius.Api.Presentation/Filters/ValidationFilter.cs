using System.Net;
using FluentValidation;

namespace Case.SoftGenius.Api.Presentation.Filters;

public class ValidationFilter<TInput> : IEndpointFilter where TInput : class
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var input = context.GetArgument<TInput>(0);
        var validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<TInput>>();
        if (validator is not null)
        {
            var result = await validator.ValidateAsync(input);
            if (!result.IsValid)
            {
                var errors = result.ToDictionary();
                return Results.ValidationProblem(errors, statusCode: (int)HttpStatusCode.BadRequest);
            }
        }
        return await next.Invoke(context);
    }

}
