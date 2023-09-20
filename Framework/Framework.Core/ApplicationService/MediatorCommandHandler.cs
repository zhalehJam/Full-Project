using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Core.ApplicationService
{
    public class MediatorCommandHandler<TCommand, TResponse> : IMediatorCommandHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
    {
        public Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResponse> Handle(TCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
