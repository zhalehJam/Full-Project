using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketContext.Domain.Tickets.DomainServices
{
    public interface IPersonIDIsValidChecker:IDomainService
    {
        bool IsValid(int personID);
    }
}
