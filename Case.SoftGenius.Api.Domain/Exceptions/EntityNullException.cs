namespace Case.SoftGenius.Api.Domain.Exceptions;

public sealed class EntityNullException(string entityName) : Exception($"Entity with name '{entityName}' is null.")
{

}
