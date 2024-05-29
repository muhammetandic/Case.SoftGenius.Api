using FluentValidation;

namespace Case.SoftGenius.Api.Application.Users.UpdateUser;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Email).EmailAddress().NotEmpty();
    }
}
