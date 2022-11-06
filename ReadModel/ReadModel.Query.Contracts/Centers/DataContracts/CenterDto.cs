using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.Centers.DataContracts;

namespace ReadModel.Query.Contracts.Centers.DataContracts
{
    public class CenterDto
    {
        public CenterDto()
        {

        }
        public Guid Id { get; set; }
        public string CenterName { get; set; }
        public int CenterID { get; set; }
        public IList<PartDto> parts { get; set; }
    }
}
