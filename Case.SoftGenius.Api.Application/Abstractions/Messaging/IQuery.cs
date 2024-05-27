using MediatR;

namespace Case.SoftGenius.Api.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>;
