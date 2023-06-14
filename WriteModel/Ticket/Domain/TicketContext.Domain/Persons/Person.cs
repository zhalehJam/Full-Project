using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Contract.Persons;
using TicketContext.Contract.Tickets;
using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Persons.Exceptions;

namespace TicketContext.Domain.Persons
{
    public class Person : EntityBase, IAggregateRoot
    {
        public Person(string name,
                      Int32 personID,
                      Guid partId,
                      RoleType roleType,
                      IPersonIDValidationChecker personIDValidationChecker,
                      IPartIDIsValidChecker partIDIsValidChecker,
                      IPersonIDDuplicateChecker persoIDDuplicateChecker,
                      IPersonIDUsedChecker personIDUsedChecker
            )
        {
            _personIDValidationChecker = personIDValidationChecker;
            _partIDIsValidChecker = partIDIsValidChecker;
            _persoIDDuplicateChecker = persoIDDuplicateChecker;
            _personIDUsedChecker = personIDUsedChecker;
            SetName(name);
            SetPersonID(personID);
            SetPartID(partId);
            SetPerosnRole(roleType);
        }

        private void SetPerosnRole(RoleType roleType)
        {
            if(!Enum.IsDefined(typeof(RoleType), roleType))
            {
                throw new InvalidRoleTypeException();
            }
            if(PersonRole != roleType)
            {
            }
            PersonRole = roleType;
        }

        protected Person()
        { }

        private void SetPartID(Guid partId)
        {
            if(!_partIDIsValidChecker.Isvalid(partId))
                throw new PartIDIsNotValidException();
            PartId = partId;
        }

        private void SetPersonID(Int32 personID)
        {
            if(personID == 0)
            {
                throw new NullOrZeroPersonIDException();
            }
            if(!_personIDValidationChecker.IsValid(personID))
            {
                throw new InvalidPersonIDException();
            }
            if(PersonID == 0 & _persoIDDuplicateChecker.IsDuplicate(personID))
            {
                throw new PersonIDIsDuplicateException();
            }

            PersonID = personID;
        }

        private void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new NullOrWhitePersonNameException();
            Name = name;
        }

        public void UpdatePersonInfo(string personName, Guid partId, RoleType personRole, IPartIDIsValidChecker partIDIsValidChecker, IPersonIsProgramSuppoerterChecker personIsProgramSuppoerterChecker)
        {
            _partIDIsValidChecker = partIDIsValidChecker;
            SetName(personName);
            SetPartID(partId);
            if(personIsProgramSuppoerterChecker.IsSupprter(PersonID) && (personRole!=RoleType.Supporter&&personRole!=RoleType.Admin ))
            {
                throw new PersonIsProgramSupporterException();
            }
            SetPerosnRole(personRole);
        }

        public void CheckPersonCanDelete(IPersonIDUsedChecker personIDUsedChecker)
        {
            _personIDUsedChecker = personIDUsedChecker;
            if(_personIDUsedChecker.IsUsed(PersonID))
                throw new PersonIDIsUsedException();
        }

        public string Name { get; private set; }
        public Int32 PersonID { get; private set; }
        public Guid PartId { get; private set; }
        public RoleType PersonRole { get; private set; }

        public readonly IPersonIDValidationChecker _personIDValidationChecker;
        public IPartIDIsValidChecker _partIDIsValidChecker;
        private readonly IPersonIDDuplicateChecker _persoIDDuplicateChecker;
        private IPersonIDUsedChecker _personIDUsedChecker;
    }
}
