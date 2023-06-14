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
        private readonly Mock<IPersonIDValidationChecker> _personIDValidationChecker = new Mock<IPersonIDValidationChecker>();
        private readonly Mock<IPartIDIsValidChecker> _partIDIsValidChecker = new Mock<IPartIDIsValidChecker>();
        private readonly Mock<IPersonIsProgramSuppoerterChecker> _personIsProgramSuppoerterChecker = new Mock<IPersonIsProgramSuppoerterChecker>();
        private readonly Mock<IPersonIDDuplicateChecker> _persoIDDuplicateChecker = new Mock<IPersonIDDuplicateChecker>();
        private readonly Mock<IPersonIDUsedChecker> _personIDUsedChecker = new Mock<IPersonIDUsedChecker>();

        private Guid centerId;
        private Guid partId;

        private Guid supporterpersonId = new Guid();
        [TestInitialize]
        public void Setup()
        {
            centerId = new Guid("dd076d63-9546-4123-85e0-e193f6c2cd22");
            partId = new Guid("c8363f00-4b86-4cd1-9a68-40818197861a");
            _personIDValidationChecker.Setup(c => c.IsValid(It.Is<Int32>(n => !(n.Equals(0) || n.ToString().Length > 7)))).Returns(true);
            _partIDIsValidChecker.Setup(c => c.Isvalid(partId)).Returns(true);
            _personIsProgramSuppoerterChecker.Setup(c => c.IsSupprter(It.IsAny<int>())).Returns(false);
            _persoIDDuplicateChecker.Setup(c => c.IsDuplicate(It.Is<Int32>(n => n.Equals(970086)))).Returns(true);
            _personIDUsedChecker.Setup(c => c.IsUsed(It.Is<Int32>(n => n.Equals(970087)))).Returns(true);

        }
        private Person Init(string personName = "ژاله جمالیوند",
                            Int32 personID = 970087,
                            RoleType roleType = RoleType.Supporter)
        {
            Person person = new Person(personName,
                                       personID,
                                       partId,
                                       roleType,
                                       _personIDValidationChecker.Object,
                                       _partIDIsValidChecker.Object,
                                       _persoIDDuplicateChecker.Object,
                                       _personIDUsedChecker.Object);

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

        public void PersonName_Retrive(string personName)
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
        public void PersonID_Retrive(Int32 personID)
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
            centerId = new Guid(centerGId);
            partId = new Guid(partGId);
            Init();
        }

        [TestMethod, TestCategory("PersonPart")]
        public void PersonPartID_Retrive()
        {
            centerId = new Guid("dd076d63-9546-4123-85e0-e193f6c2cd22");
            partId = new Guid("c8363f00-4b86-4cd1-9a68-40818197861a");
            Person person = Init();
            Assert.AreEqual(person.PartId, partId);
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
            _personIDUsedChecker.Setup(c => c.IsUsed(It.IsAny<int>())).Returns(true);

            Person person = Init();
            person.CheckPersonCanDelete(_personIDUsedChecker.Object);
        }

        [TestMethod, TestCategory("DeletePerson")]
        [DataRow(970428)]
        public void Retrive_DeletePerson(Int32 PersonID)
        {
            _personIDUsedChecker.Setup(c => c.IsUsed(It.IsAny<int>())).Returns(false);
            Person person = Init(personID: PersonID);
            person.CheckPersonCanDelete(_personIDUsedChecker.Object);
        }

        [TestMethod, TestCategory("PersonRole")]
        [ExpectedException(typeof(InvalidRoleTypeException))]
        public void InvalidRoleType_throw()
        {
            Init(roleType: 0);
        }

        [TestMethod, TestCategory("PersonRole")]
        public void SetPersonRole_retreive()
        {
            var person = Init(roleType: RoleType.User);
            Assert.AreEqual(person.PersonRole, RoleType.User);
        }

        [TestMethod, TestCategory("UpdatePersonRole")]
        [ExpectedException(typeof(InvalidRoleTypeException))]
        public void UpdateUserRole_Exception()
        {
            var person = Init(roleType: RoleType.User);
            person.UpdatePersonInfo(person.Name, person.PartId, (RoleType)0, _partIDIsValidChecker.Object, _personIsProgramSuppoerterChecker.Object);
        }

        [TestMethod, TestCategory("UpdatePersonRole")]
        [ExpectedException(typeof(PersonIsProgramSupporterException))]
        public void PersonIsProgramSupporter_Exception()
        {
            var person = Init(roleType: RoleType.User);
            _personIsProgramSuppoerterChecker.Setup(c => c.IsSupprter(It.IsAny<int>())).Returns(true);

            person.UpdatePersonInfo(person.Name, person.PartId, (RoleType)0, _partIDIsValidChecker.Object, _personIsProgramSuppoerterChecker.Object);
        }

        [TestMethod, TestCategory("UpdatePersonRole")]
        public void UpdateUserRole_retreive()
        {
            var person = Init(roleType: RoleType.User);
            person.UpdatePersonInfo(person.Name, person.PartId, RoleType.Admin, _partIDIsValidChecker.Object, _personIsProgramSuppoerterChecker.Object);
            Assert.AreEqual(person.PersonRole, RoleType.Admin);
        }
    }
}
