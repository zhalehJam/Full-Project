﻿
using ReadModel.Context.Model;
using ReadModel.Pagination;
using TicketContext.Contract.Persons;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Tickets;
using TicketContext.ReadModel.Query.Contracts.Tickets.DataContracts;

namespace TicketContext.ReadModel.Query.Facade.Tickets
{
    public class TicketQueryFacade : ITicketQueryFacade
    {
        private readonly TicketingContext _ticketContext;

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
                PersonCenterName = _ticketContext.Centers.Where(m => m.Id.Equals(_ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                       .Select(m => m.Center)
                       .First()))
                                                                .Select(m => m.CenterName)
                                                                .First(),
                ProgramId = n.ProgramId,
                ProgramName = _ticketContext.Programs.Where(m => m.Id.Equals(n.ProgramId))
                                                                .Select(m => m.ProgramName)
                                                                .First(),
                ErrorTypeid = Convert.ToInt16(n.ErrorType),
                ErrorTypeName = n.ErrorType.ToString(),
                ErrorDiscription = n.ErrorDiscription,
                SolutionDiscription = n.SolutionDiscription,
                Typeid = Convert.ToInt16(n.Type),
                TicketTypeName = n.Type.ToString(),
                TicketTime = n.TicketTime,
                TicketConditionid = Convert.ToInt16(n.TicketCondition),
                TicketConditionTypeName = n.TicketCondition.ToString(),
                SupporterPersonID = n.SupporterPersonID

            }).ToList();
            return ticketDtos;
        }

        public List<TicketDto> GetUserAllTickets(int personID, DateTime fromDate, DateTime toDate)
        {
            List<TicketDto>? ticketDtos = new List<TicketDto>();
            var userinfo = _ticketContext.Persons.Single(p => p.PersonID == personID);

            ticketDtos = _ticketContext.Ticket.Where(t => (userinfo.PersonRole == RoleType.Admin || t.SupporterPersonId == personID)
                                                          && t.TicketTime >= fromDate
                                                          && t.TicketTime <= toDate).Select(n => new TicketDto()
                                                          {
                                                              Id = n.Id,
                                                              PersonID = n.PersonID,
                                                              PersonName = _ticketContext.Persons.Where(m => m.PersonId == n.PersonID)
                                                   .Select(m => m.Name)
                                                   .First(),
                                                              PersonPartId = n.PersonPartId,
                                                              PersonPartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                    .Select(m => m.PartName)
                                                    .First(),
                                                              PersonCenterId = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                   .Select(m => m.Center)
                                                   .FirstOrDefault(),
                                           PersonCenterName = _ticketContext.Centers.Where(m => m.Id.Equals(_ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                  .Select(m => m.Center)
                                                  .First()))
                                                   .Select(m => m.CenterName)
                                                   .First(),
                                           ProgramId = n.ProgramId,
                                           ProgramName = _ticketContext.Programs.Where(m => m.Id.Equals(n.ProgramId))
                                                                            .Select(m => m.ProgramName)
                                                                            .First(),
                                           ErrorTypeid = Convert.ToInt16(n.ErrorType),
                                           ErrorTypeName = n.ErrorType.ToString(),
                                           ErrorDiscription = n.ErrorDiscription,
                                           SolutionDiscription = n.SolutionDiscription,
                                           Typeid = Convert.ToInt16(n.Type),
                                           TicketTypeName = n.Type.ToString(),
                                           TicketTime = n.TicketTime,
                                           TicketConditionid = Convert.ToInt16(n.TicketCondition),
                                           TicketConditionTypeName = n.TicketCondition.ToString(),
                                           SupporterPersonID = n.SupporterPersonID,
                                           SupporterPersonName = _ticketContext.Persons.Where(m => m.PersonID == n.SupporterPersonID)
                                                   .Select(m => m.Name)
                                                   .First()

                                       }).ToList();
            return ticketDtos;
        }

        public PagedList<TicketDto> GetAllTicketsByPage(PageParameter pageParametrs)
        {

            var ticketDtos = _ticketContext.Ticket.Select(n => new TicketDto()
            {
                Id = n.Id,
                PersonID = n.PersonID,
                PersonName = _ticketContext.Persons.Where(m => m.PersonID == n.PersonID)
                                                  .Select(m => m.Name)
                                                  .First(),
                PersonPartId = n.PersonPartId,
                PersonPartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                   .Select(m => m.PartName)
                                                   .First(),
                PersonCenterId = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                  .Select(m => m.Center)
                                                  .FirstOrDefault(),
                PersonCenterName = _ticketContext.Centers.Where(m => m.Id.Equals(_ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                                                                     .Select(m => m.Center)
                                                                                                     .First()))
                                                      .Select(m => m.CenterName)
                                                      .First(),
                ProgramId = n.ProgramId,
                ProgramName = _ticketContext.Programs.Where(m => m.Id.Equals(n.ProgramId))
                                                    .Select(m => m.ProgramName)
                                                    .First(),
                ErrorTypeid = Convert.ToInt16(n.ErrorType),
                ErrorTypeName = n.ErrorType.ToString(),
                ErrorDiscription = n.ErrorDiscription,
                SolutionDiscription = n.SolutionDiscription,
                Typeid = Convert.ToInt16(n.Type),
                TicketTypeName = n.Type.ToString(),
                TicketTime = n.TicketTime,
                TicketConditionid = Convert.ToInt16(n.TicketCondition),
                TicketConditionTypeName = n.TicketCondition.ToString(),
                SupporterPersonID = n.SupporterPersonID,
                SupporterPersonName = _ticketContext.Persons.Where(m => m.PersonID == n.SupporterPersonID)
                                                         .Select(m => m.Name)
                                                         .First()

            }).ToList();
            return PagedList<TicketDto>.ToPagedList(ticketDtos.OrderBy(t => t.TicketTime), pageParametrs.PageNumber, pageParametrs.PageSize);
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
                                                   .First(),
                PersonPartId = n.PersonPartId,
                PersonPartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                    .Select(m => m.PartName)
                                                    .First(),
                PersonCenterId = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                   .Select(m => m.Center)
                                                   .FirstOrDefault(),
                PersonCenterName = _ticketContext.Centers.Where(m => m.Id.Equals(_ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                                                                     .Select(m => m.Center)
                                                                                                     .FirstOrDefault()))
                                                       .Select(m => m.CenterName)
                                                       .First(),
                ProgramId = n.ProgramId,
                ProgramName = _ticketContext.Programs.Where(m => m.Id.Equals(n.ProgramId))
                                                     .Select(m => m.ProgramName)
                                                     .First(),
                ErrorTypeid = Convert.ToInt16(n.ErrorType),
                ErrorTypeName = n.ErrorType.ToString(),
                ErrorDiscription = n.ErrorDiscription,
                SolutionDiscription = n.SolutionDiscription,
                Typeid = Convert.ToInt16(n.Type),
                TicketTypeName = n.Type.ToString(),
                TicketTime = n.TicketTime,
                TicketConditionid = Convert.ToInt16(n.TicketCondition),
                TicketConditionTypeName = n.TicketCondition.ToString(),
                SupporterPersonID = n.SupporterPersonID,
                SupporterPersonName = _ticketContext.Persons.Where(m => m.PersonID == n.SupporterPersonID)
                                                            .Select(m => m.Name)
                                                            .First()

            }).First();
            return ticketDtos;
        }

        public PagedList<TicketDto> GetUserTicketsByDateRage(int personID, TicketQueryParameters parameters)
        {
            var userinfo = _ticketContext.Persons.Single(p => p.PersonID == personID);
            var supporterterprograms = _ticketContext.ProgramSupporters.Where(ps => ps.SupporterPersonID == userinfo.PersonID).Select(t => t.Program).ToList();
            var tickets = _ticketContext.Ticket.Where(t => (userinfo.PersonRole == RoleType.Admin || supporterterprograms.Contains(t.ProgramId))
                                                           && t.TicketTime.Date >= parameters.fromDate
                                                           && t.TicketTime <= parameters.toDate)
                                               .Select(n => new TicketDto()
                                               {
                                                   Id = n.Id,
                                                   PersonID = n.PersonID,
                                                   PersonName = _ticketContext.Persons.Where(m => m.PersonID == n.PersonID)
                                                  .Select(m => m.Name)
                                                  .First(),
                                                   PersonPartId = n.PersonPartId,
                                                   PersonPartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                   .Select(m => m.PartName)
                                                   .First(),
                                                   PersonCenterId = _ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                  .Select(m => m.Center)
                                                  .FirstOrDefault(),
                                                   PersonCenterName = _ticketContext.Centers.Where(m => m.Id.Equals(_ticketContext.Parts.Where(m => m.Id.Equals(n.PersonPartId))
                                                                                                                                        .Select(m => m.Center)
                                                                                                                                        .First()))
                                                      .Select(m => m.CenterName)
                                                      .First(),
                                                   ProgramId = n.ProgramId,
                                                   ProgramName = _ticketContext.Programs.Where(m => m.Id.Equals(n.ProgramId))
                                                    .Select(m => m.ProgramName)
                                                    .First(),
                                                   ErrorTypeid = Convert.ToInt16(n.ErrorType),
                                                   ErrorTypeName = n.ErrorType.ToString(),
                                                   ErrorDiscription = n.ErrorDiscription,
                                                   SolutionDiscription = n.SolutionDiscription,
                                                   Typeid = Convert.ToInt16(n.Type),
                                                   TicketTypeName = n.Type.ToString(),
                                                   TicketTime = n.TicketTime,
                                                   TicketConditionid = Convert.ToInt16(n.TicketCondition),
                                                   TicketConditionTypeName = n.TicketCondition.ToString(),
                                                   SupporterPersonID = n.SupporterPersonID,
                                                   SupporterPersonName = _ticketContext.Persons.Where(m => m.PersonID == n.SupporterPersonID)
                                                         .Select(m => m.Name)
                                                         .First()

                                               }).ToList();
            return PagedList<TicketDto>.ToPagedList(tickets.OrderByDescending(t => t.TicketTime), parameters.PageNumber, parameters.PageSize);
        }


    }
}
