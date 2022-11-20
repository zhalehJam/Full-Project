using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Persons.DomainServices;

namespace TicketContext.Domain.Services.Persons
{
    public class PersonIDValidationChecker : IPersonIDValidationChecker
    {
        public bool IsValid(int personID)
        {
            bool isValid = true;
            if(personID.ToString().Length>7)
                isValid = false;
            return isValid;
        }
    }
}
