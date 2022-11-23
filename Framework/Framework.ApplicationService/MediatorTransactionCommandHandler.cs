using Framework.Core.ApplicationService;
using Framework.Core.DependencyInjection;
using MediatR;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.ApplicationService
{
    public class MediatorTransactionCommandHandler<TCommand, TResponse> :IRequest<TResponse>
        where TCommand : Command
    {
        //private readonly IMediatorCommandHandler<TCommand, TResponse> _commandHandler;
        private readonly IDIContainer _dIContainer;
        private readonly IMediator _mediator;

        public MediatorTransactionCommandHandler(//IMediatorCommandHandler<TCommand, TResponse> commandHandler,
                                                 IDIContainer diContainer,
                                                 IMediator mediator)
        {
            //_commandHandler = commandHandler;
            _dIContainer = diContainer;
            _mediator = mediator;
        }


        public async Task<TResponse> Handle(TCommand command)
        {
            var unitOfWork = _dIContainer.Resolve<IUnitOfWork>();
            try
            {
                var commandHandler = _dIContainer.Resolve<IMediator>();
               //var commandHandler2 = _dIContainer.Resolve<IMediatorCommandHandler<TCommand, TResponse>>();

                return await _mediator.Send((IRequest<TResponse>)command);
                //_mediator.Send(createCenterCommand);
                //var e= await _mediator.Send<TResponse>(command< TResponse> )
                unitOfWork.Commit();
                //return _commandHandler.Handle(command);
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
