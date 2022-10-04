using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class NullOrWhiteCenterNameException:DomainException
    {
        public override string Message => CenterResource.NullOrWhiteCenterNameException;
    }
    
}
