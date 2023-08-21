using Framework.Core.Facade;
using ReadModel.Pagination;
using TicketContext.ReadModel.Query.Contracts.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons.DataContracts;
using TicketContext.ReadModel.Query.Contracts.Persons.Queries;

namespace TicketContext.ReadModel.Query.Contracts.Persons
{
    public interface IPersonQueryFacade : IQueryFacade
    {
        List<PersonDto> GetAllPersons();
        PersonDto GetPersonById(Guid Id);
        PagedList<PersonDto> GetAllPersonsByPage(PageParameter centerQueryParameter);
        PersonDto GetPersonInfoByPersonelCode(int personnelCode);
        PagedList<PersonDto>  GetPersonInfoByFilters(GetPersonInfoByFiltersQuery getPersonInfoByFiltersQuery );

    }
}
