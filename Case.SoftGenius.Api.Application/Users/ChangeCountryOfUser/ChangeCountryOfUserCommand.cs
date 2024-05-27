using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.ChangeCountryOfUser;

public sealed record class ChangeCountryOfUserCommand(uint UserId, uint CountryId) : ICommand<bool>;