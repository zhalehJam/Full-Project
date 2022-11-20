using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Programs.DomainServices;
using TicketContext.Domain.Programs.Exceptions;

namespace TicketContext.Domain.Programs
{
    public class ProgramSupporter : EntityBase
    {
        private readonly IValidSupporterPersonIDChecker _validSuporterPersonIDChecker;

        public ProgramSupporter(int supporterPersonID,
                                IValidSupporterPersonIDChecker validSuporerPersonIDChecker)
        {

            _validSuporterPersonIDChecker = validSuporerPersonIDChecker;
            SetSupporterPersonID(supporterPersonID);
        }
        protected ProgramSupporter()
        {

        }

        private void SetSupporterPersonID(int personID)
        {
            if(!_validSuporterPersonIDChecker.Isvalid(personID))
                throw new SupporterIdIsNotValidException();
            SupporterPersonID = personID;
        }

        public int SupporterPersonID { get; private set; }
    }
}
