using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Centers.DomainServices;

namespace TicketContext.Domain.Services.Centers
{
    public class PartIDValidaionChecker : IPartIDValidaionCheker
    {
        public bool ISValid(int PartID)
        {
            bool isvalid= true;
            if(PartID==0)
                isvalid=false;
            return isvalid;
        }
    }
}
