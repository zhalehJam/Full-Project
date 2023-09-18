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
        private readonly ISupporterPersonIDIsValidChecker _supporterPersonIdIsValidChecker;
        private readonly IPersonIDIsValidChecker _personIdIsValidChecker;
        private readonly IPersonInfo _personInfo;
        private readonly IProgramIDValidationChecker _programIdIsValidChecker;
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketCommandHandler(ISupporterPersonIDIsValidChecker supporterPersonIdIsValidChecker,
                                          IPersonIDIsValidChecker personIdIsValidChecker,
                                          IPersonInfo personInfo,
                                          IProgramIDValidationChecker programIdIsValidChecker,
                                          ITicketRepository ticketRepository)
        {
            _supporterPersonIdIsValidChecker = supporterPersonIdIsValidChecker;
            _personIdIsValidChecker = personIdIsValidChecker;
            _personInfo = personInfo;
            _programIdIsValidChecker = programIdIsValidChecker;
            _ticketRepository = ticketRepository;
        }
        public void Execute(CreateTicketCommand command)
        {
            Ticket ticket = new Ticket(_personIdIsValidChecker,
                                       _personInfo,
                                       _programIdIsValidChecker,
                                       _supporterPersonIdIsValidChecker,
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
