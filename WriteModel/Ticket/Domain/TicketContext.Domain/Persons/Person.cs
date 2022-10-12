using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Persons.Exceptions;

namespace TicketContext.Domain.Persons
{
    public class Person : EntityBase, IAggregateRoot
    {
        public Person(string name,
                      Int32 personID,
                      Guid centerId,
                      Guid partId,
                      IPersonIDValidationChecker personIDValidationChecker,
                      IPartIDIsValidChecker partIDIsValidChecker
            )
        {
            PersonIDValidationChecker = personIDValidationChecker;
            PartIDIsValidChecker = partIDIsValidChecker;
            SetName(name);
            SetPersonID(personID);
            SetPartID(centerId, partId);
        }

        private void SetPartID(Guid centerId, Guid partId)
        {
            if(!PartIDIsValidChecker.Isvalid(centerId, partId))
                throw new PartIDIsNotValidException();
            PartId = partId;

        }

        protected Person()
        { }

        private void SetPersonID(Int32 personID)
        {
            if(personID == 0)
            {
                throw new NullOrZeroPersonIDException();
            }
            if(!PersonIDValidationChecker.IsValid(personID))
            {
                throw new InvalidPersonIDException();
            }
            //if(PersonID != 0 && PersonID != personID)
            //{
            //    throw new CannotChangePersonIDException();
            //}

            PersonID = personID;
        }

        private void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new NullOrWhitePersonNameException();
            Name = name;
        }

        public void UpdatePersonInfo(string personName, Guid centerId, Guid partId,IPartIDIsValidChecker partIDIsValidChecker)
        {
            PartIDIsValidChecker = partIDIsValidChecker;
            SetName(personName);
            SetPartID(centerId, partId);
            //SetPersonID(personId);
        }

        public string Name { get; private set; }
        public Int32 PersonID { get; private set; }
        public Guid PartId { get; private set; }
        //public Guid CenterId { get; set; }

        public readonly IPersonIDValidationChecker PersonIDValidationChecker;
        public  IPartIDIsValidChecker PartIDIsValidChecker;
    }
}
