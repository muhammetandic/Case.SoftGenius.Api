namespace Case.SoftGenius.Api.Domain.Exceptions;

public abstract class BadRequestException(string message) : Exception(message)
{
}
