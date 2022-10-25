using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class NullOrZiroPersonIDException: DomainException
    {
        public override string Message => TicketResource.NullOrZiroPersonIDException;
    }
}
