using Microsoft.Extensions.Configuration;
using PagedList;
using ReadModel.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Tickets;
using TicketContext.ReadModel.Query.Contracts.Tickets.DataContracts;

namespace TicketContext.ReadModel.Query.Facade.Tickets
{
    public class TicketQueryFacade : ITicketQueryFacade
    {
        private readonly TicketingContext? _ticketContext;

        public TicketQueryFacade(TicketingContext ticketContext)
        {
            _ticketContext = ticketContext;
        }
        public List<TicketDto> GetAllTickets()
        {
            List<TicketDto>? ticketDtos = new List<TicketDto>();
            ticketDtos = _ticketContext.Ticket.Select(n => new TicketDto()
            {
                Id = n.Id,
                PersonID = n.PersonID,
                PersonName = _ticketContext.Persons.Where(m => m.PersonID == n.PersonID)
                                                   .Select(m => m.Name)
                                                   .FirstOrDefault(),
                PersonPartId = n.PersonPartId,
                PersonPartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                    .Select(m => m.PartName)
                                                    .FirstOrDefault(),
                PersonCenterId = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                   .Select(m => m.Center)
                                                   .FirstOrDefault(),
                PersonCenterName = _ticketContext.Centers.Where(m => m.Id.Equals(_ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                                                                     .Select(m => m.Center)
                                                                                                     .FirstOrDefault()))
                                                       .Select(m => m.CenterName)
                                                       .FirstOrDefault(),
                ProgramId = n.ProgramId,
                ProgramName = _ticketContext.Programs.Where(m => m.Id.Equals(n.ProgramId))
                                                     .Select(m => m.ProgramName)
                                                     .FirstOrDefault(),
                ErrorTypeid = Convert.ToInt16(n.ErrorType),
                ErrorTypeName = n.ErrorType.ToString(),
                ErrorDescription = n.ErrorDiscription,
                SolutionDescription = n.SolutionDiscription,
                Typeid = Convert.ToInt16(n.Type),
                TicketTypeName = n.Type.ToString(),
                TicketTime = n.TicketTime,
                TicketConditionid = Convert.ToInt16(n.TicketCondition),
                TicketConditionTypeName = n.TicketCondition.ToString(),
                SupporterPersonID = n.SupporterPersonID,
                SupporterPersonName = _ticketContext.Persons.Where(m => m.PersonID == n.PersonID)
                                                          .Select(m => m.Name)
                                                          .FirstOrDefault()

            }).ToList();
            return ticketDtos;
        }

        public PagedList<TicketDto> GetAllTicketsByPage(PageParametr pageParametrs)
        {
            PagedList<TicketDto> ticketDtos = new PagedList<TicketDto>(GetAllTickets(), pageParametrs.PageNumber, pageParametrs.PageSize);
            return ticketDtos;
        }

        public TicketDto GetTicketById(Guid Id)
        {
            TicketDto? ticketDtos = new TicketDto();
            ticketDtos = _ticketContext.Ticket.Where(n => n.Id.Equals(Id)).Select(n => new TicketDto()
            {
                Id = n.Id,
                PersonID = n.PersonID,
                PersonName = _ticketContext.Persons.Where(m => m.PersonID == n.PersonID)
                                                   .Select(m => m.Name)
                                                   .FirstOrDefault(),
                PersonPartId = n.PersonPartId,
                PersonPartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                    .Select(m => m.PartName)
                                                    .FirstOrDefault(),
                PersonCenterId = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                   .Select(m => m.Center)
                                                   .FirstOrDefault(),
                PersonCenterName = _ticketContext.Centers.Where(m => m.Id.Equals(_ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                                                                     .Select(m => m.Center)
                                                                                                     .FirstOrDefault()))
                                                       .Select(m => m.CenterName)
                                                       .FirstOrDefault(),
                ProgramId = n.ProgramId,
                ProgramName = _ticketContext.Programs.Where(m => m.Id.Equals(n.ProgramId))
                                                     .Select(m => m.ProgramName)
                                                     .FirstOrDefault(),
                ErrorTypeid = Convert.ToInt16(n.ErrorType),
                ErrorTypeName = n.ErrorType.ToString(),
                ErrorDescription = n.ErrorDiscription,
                SolutionDescription = n.SolutionDiscription,
                Typeid = Convert.ToInt16(n.Type),
                TicketTypeName = n.Type.ToString(),
                TicketTime = n.TicketTime,
                TicketConditionid = Convert.ToInt16(n.TicketCondition),
                TicketConditionTypeName = n.TicketCondition.ToString(),
                SupporterPersonID = n.SupporterPersonID,
                SupporterPersonName = _ticketContext.Persons.Where(m => m.PersonID == n.PersonID)
                                                            .Select(m => m.Name)
                                                            .FirstOrDefault()

            }).FirstOrDefault();
            return ticketDtos;
        }
    }
}
