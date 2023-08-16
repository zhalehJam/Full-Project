using ReadModel.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Contract.Persons;
using TicketContext.ReadModel.Query.Contracts.Persons.DataContracts;

namespace TicketContext.ReadModel.Query.Contracts.Persons.Queries
{
    public class GetPersonInfoByFiltersQuery: PaginationQueryParameters
    {
        public int PersonCode { get; set; }
        public Guid CenterId { get; set; }
        public Guid PartId { get; set; }
        public string PersonName { get; set; } = "";
        public RoleType userRole { get; set; }
    }
}
