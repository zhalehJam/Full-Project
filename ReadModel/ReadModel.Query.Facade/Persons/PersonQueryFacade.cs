using Microsoft.Extensions.Configuration;
using PagedList;
using ReadModel.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons;
using TicketContext.ReadModel.Query.Contracts.Persons.DataContracts;

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
                PartName = _ticketContext.Parts.Where(m => m.Id.Equals(n.PartId))
                                               .Select(m => m.PartName)
                                               .FirstOrDefault()
                                               .ToString(),
                CenterName = _ticketContext.Centers.Where(m => m.Parts.Any(q => q.Id.Equals(n.PartId)))
                                                   .Select(m => m.CenterName)
                                                   .FirstOrDefault()
                                                   .ToString()
            }).ToList();
            return personDtos;
        }

        public PagedList<PersonDto> GetAllPersonsByPage(PageParametr pageparameters)
        {
            PagedList<PersonDto> personDtos = new PagedList<PersonDto>(GetAllPersons(), pageparameters.PageNumber, pageparameters.PageSize);
            return personDtos;
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
                                                            .FirstOrDefault()
                                                            .ToString(),
                             CenterName = _ticketContext.Centers.Where(m => m.Parts.Any(q => q.Id.Equals(n.PartId)))
                                                                .Select(m => m.CenterName)
                                                                .FirstOrDefault()
                                                                .ToString()
                         }).FirstOrDefault();

            return personDtos;
        }
    }
}
