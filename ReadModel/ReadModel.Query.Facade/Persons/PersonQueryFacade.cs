using MediatR;
using Microsoft.Extensions.Configuration;
using ReadModel.Context.Model;
using ReadModel.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons;
using TicketContext.ReadModel.Query.Contracts.Persons.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons.Queries;

namespace TicketContext.ReadModel.Query.Facade.Persons
{
    public class PersonQueryFacade : IPersonQueryFacade
    {
        private readonly TicketingContext _ticketContext;

        public PersonQueryFacade(TicketingContext ticketContext)
        {
            _ticketContext = ticketContext;
        }
        public List<PersonDto> GetAllPersons()
        {
            List<PersonDto> personDtos = new List<PersonDto>();

            personDtos = _ticketContext.Persons.Select(n => new PersonDto()
            {
                Id = n.Id,
                PartId = n.PartId,
                PersonID = n.PersonID,
                PersonName = n.Name,
                PartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PartId)).Count() > 0 ? _ticketContext.Parts.Where(m => m.Id.Equals(n.PartId))
                                               .Select(m => m.PartName)
                                               .First()
                                               .ToString() : "",
                CenterName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PartId))
                                                 .Count() > 0 ? _ticketContext.Centers.Where(m => m.Parts.Any(q => q.Id.Equals(n.PartId)))
                                                                                      .Select(m => m.CenterName)
                                                                                      .First()
                                                                                      .ToString() : "",
                PersonRole = n.PersonRole
            }).ToList();
            return personDtos;
        }

        public PagedList<PersonDto> GetAllPersonsByPage(PageParameter pageparameters)
        {
            return PagedList<PersonDto>.ToPagedList(GetAllPersons().OrderBy(p => p.PersonName), pageparameters.PageNumber, pageparameters.PageSize);

        }
        public PersonDto GetPersonById(Guid Id)
        {
            PersonDto personDtos = new PersonDto();

            personDtos = _ticketContext.
                         Persons.
                         Where(n => n.Id.Equals(Id)).Select(n => new PersonDto()
                         {
                             Id = n.Id,
                             PartId = n.PartId,
                             PersonID = n.PersonID,
                             PersonName = n.Name,
                             PartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PartId))
                                                            .Select(m => m.PartName)
                                                            .First()
                                                            .ToString(),
                             CenterName = _ticketContext.Centers.Where(m => m.Parts.Any(q => q.Id.Equals(n.PartId)))
                                                                .Select(m => m.CenterName)
                                                                .First()
                                                                .ToString(),
                             PersonRole = n.PersonRole
                         }).FirstOrDefault() ?? new PersonDto();

            return personDtos;
        }

        public PagedList<PersonDto> GetPersonInfoByFilters(GetPersonInfoByFiltersQuery parameters)
        {
            List<PersonDto> personDtos = new List<PersonDto>();
            var persosInfo = _ticketContext.Persons.AsQueryable();

            if (parameters.PersonCode != 0)
            {
                persosInfo = persosInfo.Where(p => p.PersonID == parameters.PersonCode);
            }
            if (parameters.CenterId != Guid.Empty)
            {
                var ddt = _ticketContext.Parts.Where(r => r.Center == parameters.CenterId).AsQueryable();

                persosInfo = persosInfo.Where(p => ddt.Any(r => r.Id == p.PartId));

            }
            if (parameters.PartId != Guid.Empty)
            {
                persosInfo = persosInfo.Where(p => p.PartId == parameters.PartId);

            }
            if (parameters.PersonName != string.Empty)
            {
                persosInfo = persosInfo.Where(p => p.Name.Contains(parameters.PersonName));

            }
            if (parameters.userRole != 0)
            {
                persosInfo = persosInfo.Where(p => p.PersonRole == parameters.userRole);

            }

            personDtos = persosInfo.
                         Select(n => new PersonDto()
                         {
                             Id = n.Id,
                             PartId = n.PartId,
                             PersonID = n.PersonID,
                             PersonName = n.Name,
                             PartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PartId))
                                                            .Select(m => m.PartName)
                                                            .First()
                                                            .ToString(),
                             CenterName = _ticketContext.Centers.Where(m => m.Parts.Any(q => q.Id.Equals(n.PartId)))
                                                                .Select(m => m.CenterName)
                                                                .First()
                                                                .ToString(),
                             PersonRole = n.PersonRole
                         }).ToList();
            return PagedList<PersonDto>.ToPagedList(personDtos, parameters.PageNumber, parameters.PageSize);
        }

        public PersonDto GetPersonInfoByPersonelCode(int personnelCode)
        {
            var person = _ticketContext.Persons.Where(p => p.PersonID == personnelCode).Select(n => n);
            if (!person.Any()) { return new PersonDto(); }
            else
                return _ticketContext.Persons.Where(p => p.PersonID == personnelCode).Select(n => new PersonDto()
                {
                    Id = n.Id,
                    PersonID = n.PersonID,
                    PartId = n.PartId,
                    CenterName = _ticketContext.Centers.Single(c => c.Id == (_ticketContext.Parts.Single(p => p.Id == n.PartId).Center)).CenterName,
                    PartName = _ticketContext.Parts.Single(p => p.Id == n.PartId).PartName,
                    PersonName = n.Name,
                    PersonRole = n.PersonRole
                }).First();
        }
    }
}
