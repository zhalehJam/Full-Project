using MediatR;
using System.Threading.Tasks;

namespace Framework.Core.ApplicationService
{
    public interface IMediatorCommand
    {
        Task<TResponse> Send<TCommand, TResponse>(TCommand command )    where TCommand : IRequest<TResponse>;
    }
}
