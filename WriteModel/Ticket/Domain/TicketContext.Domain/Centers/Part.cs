using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Centers.Exceptions;

namespace TicketContext.Domain.Centers
{
    public class Part : EntityBase
    {
        private readonly IPartIDValidaionCheker PartIDValidaionCheker;

        public Part(string partName,
            int partID,
            IPartIDValidaionCheker partIDValidaionCheker)
        {
            PartIDValidaionCheker = partIDValidaionCheker;
            SetPartName(partName);
            SetPartID(partID);
        }
        protected Part(string partName,
            int partID)
        {
            PartName = partName;
            PartID = partID;
        }

        private void SetPartID(int partID)
        {
            if(!PartIDValidaionCheker.ISValid(partID))
                throw new PartIDIsNotValidException();
            PartID = partID;

        }

        private void SetPartName(string partName)
        {
            if(string.IsNullOrWhiteSpace(partName))
                throw new NullOrWhitePartNameException();
            PartName = partName;
        }

        public string PartName { get; private set; }
        public int PartID { get; private set; }

    }
}
