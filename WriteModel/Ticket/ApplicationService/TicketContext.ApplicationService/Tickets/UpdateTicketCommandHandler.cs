using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Tickets;
using TicketContext.Domain.Tickets;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.ApplicationService.Tickets
{
    public class UpdateTicketCommandHandler : ICommandHandler<UpdateTicketCommand>
    {
        private readonly IPersonIDIsValidChecker _personIdIsValidChecker;
        private readonly IPersonInfo _personInfo;
        private readonly IProgramIDValidationChecker _programIdIsValidChecker;
        private readonly ITicketRepository _ticketRepository;

        public UpdateTicketCommandHandler(IPersonIDIsValidChecker personIdIsValidChecker,
                                          IPersonInfo personInfo,
                                          IProgramIDValidationChecker programIdIsValidChecker,
                                          ITicketRepository ticketRepository)
        {
            _personIdIsValidChecker = personIdIsValidChecker;
            _personInfo = personInfo;
            _programIdIsValidChecker = programIdIsValidChecker;
            _ticketRepository = ticketRepository;
        }
        public void Execute(UpdateTicketCommand command)
        {
            Ticket ticket = _ticketRepository.GetByID(command.Id);
            ticket.UpdateTicketInfo(_personIdIsValidChecker,
                                   _personInfo,
                                   _programIdIsValidChecker,
                                   command.EditorPersonID,
                                   command.PersonID,
                                   command.ProgramId,
                                   command.Type,
                                   command.ErrorType,
                                   command.ErrorDiscription,
                                   command.SolutionDiscription,
                                   command.TicketTime, command.TicketCondition);
        }
    }
}
