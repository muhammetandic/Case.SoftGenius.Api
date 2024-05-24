namespace Case.SoftGenius.Api.Domain.Exceptions;

public abstract class NotFoundException(int Id) : Exception($"Entity with Id '{Id}' not found.")
{
}
