using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.DataContracts.Shared;

namespace TicketContext.ReadModel.Query.Contracts.DataContracts
{
    public class CenterQueryParameter:PaginationQueryParameters
    {
        public Guid Id { get; set; }
        public string? CenterName { get; set ; }
        public int CenterID { get; set; }
        public string? PartName { get; set; }
        public int PartID { get; set; } 

    }
}
