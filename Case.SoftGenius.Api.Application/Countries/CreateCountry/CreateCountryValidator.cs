using FluentValidation;

namespace Case.SoftGenius.Api.Application.Countries.CreateCountry;

public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
{
    public CreateCountryValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}
