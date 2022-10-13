using Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketContext.Domain.Programs.DomainServices
{
    public interface IProgramNameDuplicateChecker:IDomainService
    {
        bool IsDuplicated(string programName);
    }
}
