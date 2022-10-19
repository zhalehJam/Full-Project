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

        public ProgramSupporter(Int32 supporterPersonID,
                                IValidSupporterPersonIDChecker validSuporerPersonIDChecker)
        {

            _validSuporterPersonIDChecker = validSuporerPersonIDChecker;
            SetSupporterPersonID(supporterPersonID);
        }
        protected ProgramSupporter(Int32 supporterPersonID)
        {
            SupporterPersonID = supporterPersonID;
        }

        private void SetSupporterPersonID(int personID)
        {
            if(!_validSuporterPersonIDChecker.Isvalid(personID))
                throw new SupporterIdIsNotValidException();
            SupporterPersonID = personID;
        }

        public Int32 SupporterPersonID { get; private set; }
    }
}
