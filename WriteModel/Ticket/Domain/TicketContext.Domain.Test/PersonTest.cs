using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        private readonly Mock<IPersoIDDuplicateChecker> _persoIDDuplicateChecker = new Mock<IPersoIDDuplicateChecker>();

        private Guid centerId;
        private Guid partId;

        [TestInitialize]
        public void Setup()
        {
            centerId = new Guid("dd076d63-9546-4123-85e0-e193f6c2cd22");
            partId = new Guid("c8363f00-4b86-4cd1-9a68-40818197861a");
            _personIDValidationChecker.Setup(c => c.IsValid(It.Is<int>(n => !(n.Equals(0) || n.ToString().Length > 7)))).Returns(true);
            _partIDIsValidChecker.Setup(c => c.Isvalid(centerId, partId)).Returns(true);
            _persoIDDuplicateChecker.Setup(c=>c.IsDuplicate(It.Is<int>(n=>n.Equals(970086)))).Returns(true);


        }
        private Person Init(string personName = "ژاله جمالیوند",
                            Int32 personID = 970087)
        {
            Person person = new Person(personName,
                                       personID,
                                       centerId,
                                       partId,
                                       _personIDValidationChecker.Object,
                                       _partIDIsValidChecker.Object,
                                       _persoIDDuplicateChecker.Object);

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

        [TestMethod, TestCategory("Person")]
        [DataRow("ژاله جمالیوند")]

        public void PersonName_Retrive(string personName)
        {
            Person person = Init(personName: personName);
            Assert.AreEqual(person.Name, personName);
        }

        [TestMethod, TestCategory("Person")]
        [ExpectedException(typeof(NullOrZeroPersonIDException))]
        [DataRow(0)]
        [DataRow(null)]
        public void NullOrZeroPersonID_Throw_NullOrZeroPersonIDException(Int32 personID)
        {
            Person person = Init(personID: personID);
        }

        [TestMethod, TestCategory("Person")]
        [ExpectedException(typeof(InvalidPersonIDException))]
        [DataRow(40100192)]
        public void InvalidPersonID_Throw_InvalidPersonIDException(Int32 personID)
        {
            Person person = Init(personID: personID);
        }

        [TestMethod, TestCategory("Person")]
        [DataRow(970428)]
        public void PersonID_Retrive(Int32 personID)
        {
            Person person = Init(personID: personID);
            Assert.AreEqual(person.PersonID, personID);
        }

        [TestMethod, TestCategory("Person")]
        [ExpectedException(typeof(PartIDIsNotValidException))]
        [DataRow("c8363f00-4b86-4cd1-9a68-40818197861a", "c8363f00-4b86-4cd1-9a68-40818197861a")]
        [DataRow("dd076d63-9546-4123-85e0-e193f6c2cd22", "dd076d63-9546-4123-85e0-e193f6c2cd22")]

        public void PartIDIsNotValid_throw_PartIDIsNotValidException(string centerGId,string partGId)
        {
            centerId = new Guid(centerGId);
            partId = new Guid(partGId);
            Init();
        }

        [TestMethod, TestCategory("Person")]
        public void PersonPartID_Retrive()
        {
            centerId = new Guid("dd076d63-9546-4123-85e0-e193f6c2cd22");
            partId = new Guid("c8363f00-4b86-4cd1-9a68-40818197861a");
            Person person = Init();
            Assert.AreEqual(person.PartId,partId);
        }

        [TestMethod, TestCategory("Person")]
        [ExpectedException(typeof(PersonIDIsDuplicateException))]
        [DataRow(970086)]
        public void PersonIDIsDuplicate_throw_PersonIDIsDuplicateException(Int32 personID)
        {
            Person person = Init(personID:personID);
        }

    }
}
