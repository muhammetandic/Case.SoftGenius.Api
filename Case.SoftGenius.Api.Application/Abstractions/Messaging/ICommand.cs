using MediatR;

namespace Case.SoftGenius.Api.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>;
