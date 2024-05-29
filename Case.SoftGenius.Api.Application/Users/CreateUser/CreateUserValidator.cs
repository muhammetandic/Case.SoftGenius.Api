using FluentValidation;

namespace Case.SoftGenius.Api.Application.Users.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Email).EmailAddress().NotEmpty();
    }
}
