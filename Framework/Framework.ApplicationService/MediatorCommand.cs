using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;
using MediatR;
using System.Threading.Tasks;

namespace Framework.ApplicationService
{
    public class MediatorCommand : IMediatorCommand
    {
        private readonly IDIContainer _dIContainer;
        private readonly IMediator _mediator;

        public MediatorCommand(IDIContainer dIContainer, IMediator mediator)
        {
            _dIContainer = dIContainer;
            _mediator = mediator;
        }
        public async Task<TResponse> Send<TCommand, TResponse>(TCommand command) where TCommand : IRequest<TResponse>
        {
            var commandHandler1 = _dIContainer.Resolve<IMediator>();
            var unitOfWork = _dIContainer.Resolve<IUnitOfWork>();

            var e = await _mediator.Send(command);
            unitOfWork.Commit();
            return (TResponse)e;
        }
    }
}
