using MediatR;
using System.Threading.Tasks;

namespace Framework.Core.ApplicationService
{
    public interface IMediatorCommandHandler<TCommand, TResponse> :IHandler , IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
    {
        Task<TResponse> Handle(TCommand command);
    }
}
