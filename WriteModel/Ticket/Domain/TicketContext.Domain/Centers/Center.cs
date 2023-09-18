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
            CenterIdValidationCheck = validationCheck;
            CenterIdDuplicationCheck = duplicationCheck;
            _partIdUsedChecker = partIDUsedChecker;
            SetCenterName(centerName);
            SetCenterID(centerID);
        }
        protected Center() { }
        private void SetCenterID(int centerID)
        {
            if(!CenterIdValidationCheck.IsValid(centerID))
            {
                throw new CenterIDIsNotValidException();
            }
            if(CenterIdDuplicationCheck.IsDuplicate(centerID))
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
            if(Parts.Count(n => n.PartID == part.PartID) != 0)
            {
                throw new PartIDIsDuplicatedException();
            }
            Parts.Add(part);
        }
        public void DeletePart(IPartIDUsedChecker partIDUsedChecker, int partID)
        {
            _partIdUsedChecker = partIDUsedChecker;
            var selectedpart = Parts.FirstOrDefault(n => n.PartID == partID);
            if(selectedpart == null)
            {
                throw new PartIDIsNotExistException();
            }
            if(_partIdUsedChecker.IsUsed(selectedpart.Id))
            {
                throw new PartIDIsUsedException();
            }
            Parts.Remove(selectedpart);
        }

        public void CanDeleteCenter(ICenterIsUsedChecker centerIsUsedCheker)
        {
            CenterIsUsedChecker = centerIsUsedCheker;
            if(CenterIsUsedChecker.IsUsed(Id))
            {
                throw new CenterIsUsedException();
            }
        }

        public void UpdateCenterName(string name)
        {
            SetCenterName(name);
        }
        public string CenterName { get; private set; }
        public int CenterID { get; private set; }
        public readonly ICenterIDValidationCheck CenterIdValidationCheck;
        public readonly ICenterIDDuplicationCheck CenterIdDuplicationCheck;
        public ICenterIsUsedChecker CenterIsUsedChecker;
        private IPartIDUsedChecker _partIdUsedChecker;

        public ICollection<Part> Parts { get; private set; } = new HashSet<Part>();

    }
}
