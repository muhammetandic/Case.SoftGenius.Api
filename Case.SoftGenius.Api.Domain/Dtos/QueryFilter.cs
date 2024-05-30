namespace Case.SoftGenius.Api.Domain.Dtos;

public sealed record QueryFilter(int Page = 0, int PageSize = 10, bool All = false);
