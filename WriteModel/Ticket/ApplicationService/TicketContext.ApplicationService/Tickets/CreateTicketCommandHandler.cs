using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ApplicationService.Contract.Tickets;
using TicketContext.Domain.Tickets;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.ApplicationService.Tickets
{
    public class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand>
    {
        private readonly ISupporterPersonIDIsValidChecker _supporterPersonIDIsValidChecker;
        private readonly IPersonIDIsValidChecker _personIDIsValidChecker;
        private readonly IPersonInfo _personInfo;
        private readonly IProgramIDValidationChecker _programIDIsValidChecker;
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketCommandHandler(ISupporterPersonIDIsValidChecker supporterPersonIDIsValidChecker,
                                          IPersonIDIsValidChecker personIDIsValidChecker,
                                          IPersonInfo personInfo,
                                          IProgramIDValidationChecker programIDIsValidChecker,
                                          ITicketRepository ticketRepository)
        {
            _supporterPersonIDIsValidChecker = supporterPersonIDIsValidChecker;
            _personIDIsValidChecker = personIDIsValidChecker;
            _personInfo = personInfo;
            _programIDIsValidChecker = programIDIsValidChecker;
            _ticketRepository = ticketRepository;
        }
        public void Execute(CreateTicketCommand command)
        {
            Ticket ticket = new Ticket(_personIDIsValidChecker,
                                       _personInfo,
                                       _programIDIsValidChecker,
                                       _supporterPersonIDIsValidChecker,
                                       command.SupporterPersonID,
                                       command.PersonID,
                                       command.ProgramId,
                                       command.Type,
                                       command.ErrorType,
                                       command.ErrorDiscription,
                                       command.SolutionDiscription,
                                       command.TicketTime,
                                       command.TicketCondition);
            _ticketRepository.Add(ticket);
        }
    }
}
