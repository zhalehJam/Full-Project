using Framework.Core.Domain;
using Framework.Domain;
using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Centers.Exceptions;

namespace TicketContext.Domain.Centers
{
    public class Center : EntityBase, IAggregateRoot
    {
        public Center(ICenterIDValidationCheck validationCheck,
                      ICenterIDDuplicationCheck duplicationCheck,
                      IPartIDUsedChecker partIDUsedChecker,
                      string centerName,
                      int centerID)
        {
            CenterIDValidationCheck = validationCheck;
            CenterIDDuplicationCheck = duplicationCheck;
            _partIDUsedChecker = partIDUsedChecker;
            SetCenterName(centerName);
            SetCenterID(centerID);
        }
        protected Center() { }
        private void SetCenterID(int centerID)
        {
            if(!CenterIDValidationCheck.IsValid(centerID))
            {
                throw new CenterIDIsNotValidException();
            }
            if(CenterIDDuplicationCheck.IsDuplicate(centerID))
                throw new CenterIDDuplicationException();
            CenterID = centerID;
        }

        private void SetCenterName(string centerName)
        {
            if(string.IsNullOrWhiteSpace(centerName))
            {
                throw new NullOrWhiteCenterNameException();
            }
            CenterName = centerName;
        }

        public void AddPart(Part part)
        {
            if(Parts.Where(n => n.PartID == part.PartID).Count() != 0)
            {
                throw new PartIDIsDuplicatedException();
            }
            Parts.Add(part);
        }
        public void DeletePart(int partID)
        {
            var selectedpart = Parts.Where(n => n.PartID == partID).FirstOrDefault();
            if(selectedpart == null)
            {
                throw new PartIDIsNotExistException();
            }
            if(_partIDUsedChecker.IsUsed(selectedpart.Id))
            {
                throw new PartIDIsUsedException();
            }
            Parts.Remove(selectedpart);
        }

        public string CenterName { get; private set; }
        public int CenterID { get; private set; }
        public readonly ICenterIDValidationCheck CenterIDValidationCheck;
        public readonly ICenterIDDuplicationCheck CenterIDDuplicationCheck;
        private readonly IPartIDUsedChecker _partIDUsedChecker;

        public ICollection<Part> Parts { get; private set; } = new HashSet<Part>();

    }
}
