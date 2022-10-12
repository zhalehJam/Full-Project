using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketContext.Domain.Persons.DomainServices
{
    public interface IPersonIDValidationChecker:IDomainService
    {
        bool IsValid(Int32 personID);
    }
}
