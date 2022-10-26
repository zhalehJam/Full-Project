using Framework.Core.ApplicationService;
using TicketContext.ApplicationService.Contract.Tickets;
using TicketContext.Domain.Tickets;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.ApplicationService.Tickets
{
    public class UpdateTicketCommandHandler : ICommandHandler<UpdateTicketCommand>
    {
        private readonly IPersonIDIsValidChecker _personIDIsValidChecker;
        private readonly IPersonInfo _personInfo;
        private readonly IProgramIDValidationChecker _programIDIsValidChecker;
        private readonly ITicketRepository _ticketRepository;

        public UpdateTicketCommandHandler(IPersonIDIsValidChecker personIDIsValidChecker,
                                          IPersonInfo personInfo,
                                          IProgramIDValidationChecker programIDIsValidChecker,
                                          ITicketRepository ticketRepository)
        {
            _personIDIsValidChecker = personIDIsValidChecker;
            _personInfo = personInfo;
            _programIDIsValidChecker = programIDIsValidChecker;
            _ticketRepository = ticketRepository;
        }
        public void Execute(UpdateTicketCommand command)
        {
            Ticket ticket = _ticketRepository.GetByID(command.Id);
            ticket.UpdateTicketInfo(_personIDIsValidChecker,
                                   _personInfo,
                                   _programIDIsValidChecker,
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
