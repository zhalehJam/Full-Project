using Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketContext.ApplicationService.Contract.Persons
{
    public class CreatePersonCommand : Command
    {
        public string? Name { get; set; }
        public Int32 PersonID { get; set; }
        public Guid CenterId { get; set; }
        public Guid PartId { get; set; }
    }
}
