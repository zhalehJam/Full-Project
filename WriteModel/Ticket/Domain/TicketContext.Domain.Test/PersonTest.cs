using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicketContext.Contract.Persons;
using TicketContext.Domain.Persons;
using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Persons.Exceptions;

namespace TicketContext.Domain.Test
{
    [TestClass]
    public class PersonTest
    {
        private readonly Mock<IPersonIDValidationChecker> _personIdValidationChecker = new();
        private readonly Mock<IPartIDIsValidChecker> _partIdIsValidChecker = new();
        private readonly Mock<IPersonIsProgramSupporterChecker> _personIsProgramSupporterChecker = new();
        private readonly Mock<IPersonIDDuplicateChecker> _persoIdDuplicateChecker = new();
        private readonly Mock<IPersonIDUsedChecker> _personIdUsedChecker = new();
         
        private Guid _partId;
         
        [TestInitialize]
        public void Setup()
        { 
            _partId = new Guid("c8363f00-4b86-4cd1-9a68-40818197861a");
            _personIdValidationChecker.Setup(c => c.IsValid(It.Is<Int32>(n => !(n.Equals(0) || n.ToString().Length > 7)))).Returns(true);
            _partIdIsValidChecker.Setup(c => c.IsValid(_partId)).Returns(true);
            _personIsProgramSupporterChecker.Setup(c => c.IsSupporter(It.IsAny<int>())).Returns(false);
            _persoIdDuplicateChecker.Setup(c => c.IsDuplicate(It.Is<Int32>(n => n.Equals(970086)))).Returns(true);
            _personIdUsedChecker.Setup(c => c.IsUsed(It.Is<Int32>(n => n.Equals(970087)))).Returns(true);

        }
        private Person Init(string personName = "ژاله جمالیوند",
                            Int32 personID = 970087,
                            RoleType roleType = RoleType.Supporter)
        {
            Person person = new Person(personName,
                                       personID,
                                       _partId,
                                       roleType,
                                       _personIdValidationChecker.Object,
                                       _partIdIsValidChecker.Object,
                                       _persoIdDuplicateChecker.Object,
                                       _personIdUsedChecker.Object);

            return person;
        }

        [TestMethod, TestCategory("Person")]
        [ExpectedException(typeof(NullOrWhitePersonNameException))]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void NullORWhiteSpaceCenterName_Throw_NullOrWhiteCenterNameException(string personName)
        {
            Person person = Init(personName: personName);
        }

        [TestMethod, TestCategory("CreatePerson")]
        [DataRow("ژاله جمالیوند")]

        public void PersonName_Retrieve(string personName)
        {
            Person person = Init(personName: personName);
            Assert.AreEqual(person.Name, personName);
        }

        [TestMethod, TestCategory("CreatePerson")]
        [ExpectedException(typeof(NullOrZeroPersonIDException))]
        [DataRow(0)]
        [DataRow(null)]
        public void NullOrZeroPersonID_Throw_NullOrZeroPersonIDException(Int32 personID)
        {
            Person person = Init(personID: personID);
        }

        [TestMethod, TestCategory("CreatePerson")]
        [ExpectedException(typeof(InvalidPersonIDException))]
        [DataRow(40100192)]
        public void InvalidPersonID_Throw_InvalidPersonIDException(Int32 personID)
        {
            Person person = Init(personID: personID);
        }

        [TestMethod, TestCategory("CreatePerson")]
        [DataRow(970428)]
        public void PersonID_Retrieve(Int32 personID)
        {
            Person person = Init(personID: personID);
            Assert.AreEqual(person.PersonID, personID);
        }

        [TestMethod, TestCategory("PersonPart")]
        [ExpectedException(typeof(PartIDIsNotValidException))]
        //[DataRow("c8363f00-4b86-4cd1-9a68-40818197861a", "c8363f00-4b86-4cd1-9a68-40818197861a")]
        [DataRow("dd076d63-9546-4123-85e0-e193f6c2cd22", "dd076d63-9546-4123-85e0-e193f6c2cd22")]

        public void PartIDIsNotValid_throw_PartIDIsNotValidException(string centerGId, string partGId)
        { 
            _partId = new Guid(partGId);
            Init();
        }

        [TestMethod, TestCategory("PersonPart")]
        public void PersonPartID_Retreive()
        {
            _partId = new Guid("c8363f00-4b86-4cd1-9a68-40818197861a");
            Person person = Init();
            Assert.AreEqual(person.PartId, _partId);
        }

        [TestMethod, TestCategory("CreatePerson")]
        [ExpectedException(typeof(PersonIDIsDuplicateException))]
        [DataRow(970086)]
        public void PersonIDIsDuplicate_throw_PersonIDIsDuplicateException(Int32 personID)
        {
            Init(personID: personID);
        }

        [TestMethod, TestCategory("DeletePerson")]
        [ExpectedException(typeof(PersonIDIsUsedException))]
        public void PersonIDIsUsed_throw_PersonIDIsUsedException()
        {
            _personIdUsedChecker.Setup(c => c.IsUsed(It.IsAny<int>())).Returns(true);

            Person person = Init();
            person.CheckPersonCanDelete(_personIdUsedChecker.Object);
        }

        [TestMethod, TestCategory("DeletePerson")]
        [DataRow(970428)]
        public void Retrieve_DeletePerson(Int32 PersonID)
        {
            _personIdUsedChecker.Setup(c => c.IsUsed(It.IsAny<int>())).Returns(false);
            Person person = Init(personID: PersonID);
            person.CheckPersonCanDelete(_personIdUsedChecker.Object);
        }

        [TestMethod, TestCategory("PersonRole")]
        [ExpectedException(typeof(InvalidRoleTypeException))]
        public void InvalidRoleType_throw()
        {
            Init(roleType: 0);
        }

        [TestMethod, TestCategory("PersonRole")]
        public void SetPersonRole_retrieve()
        {
            var person = Init(roleType: RoleType.User);
            Assert.AreEqual(person.PersonRole, RoleType.User);
        }

        [TestMethod, TestCategory("UpdatePersonRole")]
        [ExpectedException(typeof(InvalidRoleTypeException))]
        public void UpdateUserRole_Exception()
        {
            var person = Init(roleType: RoleType.User);
            person.UpdatePersonInfo(person.Name, person.PartId, (RoleType)0, _partIdIsValidChecker.Object, _personIsProgramSupporterChecker.Object);
        }

        [TestMethod, TestCategory("UpdatePersonRole")]
        [ExpectedException(typeof(PersonIsProgramSupporterException))]
        public void PersonIsProgramSupporter_Exception()
        {
            var person = Init(roleType: RoleType.User);
            _personIsProgramSupporterChecker.Setup(c => c.IsSupporter(It.IsAny<int>())).Returns(true);

            person.UpdatePersonInfo(person.Name, person.PartId, (RoleType)0, _partIdIsValidChecker.Object, _personIsProgramSupporterChecker.Object);
        }

        [TestMethod, TestCategory("UpdatePersonRole")]
        public void UpdateUserRole_retrieve()
        {
            var person = Init(roleType: RoleType.User);
            person.UpdatePersonInfo(person.Name, person.PartId, RoleType.Admin, _partIdIsValidChecker.Object, _personIsProgramSupporterChecker.Object);
            Assert.AreEqual(person.PersonRole, RoleType.Admin);
        }
    }
}
