using TicketContext.ReadModel.Query.Contracts.DataContracts.Shared;

namespace TicketContext.ReadModel.Query.Contracts.DataContracts
{
    public class TicketQueryParameters : PaginationQueryParameters 
    {
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
}
