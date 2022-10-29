using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketContext.ReadModel.Query.Contracts.Centers.DataContracts
{
    public class PartDto
    {
        public Guid Id { get; set; }
        public Guid Center { get; set; }
        public string? PartName { get; set; }
        public int PartID { get; set; }

    }
}
