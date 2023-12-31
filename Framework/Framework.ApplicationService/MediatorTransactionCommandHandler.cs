using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.ApplicationService
{
    public class MediatorTransactionCommandHandler<TCommand, TResponse> : IRequest<TResponse> where TCommand : Command
    {

        private readonly IDIContainer _dIContainer;
        private readonly IMediator _mediator;

        public MediatorTransactionCommandHandler(IDIContainer diContainer,
                                                 IMediator mediator)
        {
            _dIContainer = diContainer;
            _mediator = mediator;
        }
         
        public async Task<TResponse> Handle(TCommand command)
        {
            var unitOfWork = _dIContainer.Resolve<IUnitOfWork>();
            try
            {
                var commandHandler = _dIContainer.Resolve<IMediator>();

                return await _mediator.Send((IRequest<TResponse>)command);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
