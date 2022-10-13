using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Resource;

namespace TicketContext.Domain.Programs.Exceptions
{
    public class NullOrWhiteProgramNameException:DomainException
    {
        public override string Message => ProgramResource.NullOrWhiteProgramNameException;
    }

    public class ProgramNameIsDupliateException:DomainException
    {
        public override string Message => ProgramResource.ProgramNameIsDupliateException;
    }
}
