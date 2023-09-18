using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Centers.Exceptions;

namespace TicketContext.Domain.Test
{
    [TestClass]
    public class CenterTest
    {
        private readonly Mock<ICenterIDValidationCheck> _centerIdValidationCheck = new();
        private readonly Mock<ICenterIDDuplicationCheck> _centerIdDuplicationCheck = new();
        private readonly Mock<IPartIDValidaionCheker> _partIdValidationChecker = new();
        private readonly Mock<IPartIDUsedChecker> _partIdUsedChecker = new();
        private readonly Mock<ICenterIsUsedChecker> _centerIsUsedChecker = new();
        private Guid _usedGuid;
        [TestInitialize]
        public void Setup()
        {
            _usedGuid = new Guid("fe8ff0f8-5e56-4402-8e38-991ea0283985");
            _centerIdValidationCheck.Setup(c => c.IsValid(It.IsAny<int>())).Returns(true);
            _centerIdDuplicationCheck.Setup(c => c.IsDuplicate(It.IsAny<int>())).Returns(false);
            _partIdValidationChecker.Setup(c => c.ISValid(It.Is<int>(n => !n.Equals(0)))).Returns(true);
            _partIdUsedChecker.Setup(c => c.IsUsed(It.Is<Guid>(n => n.Equals(_usedGuid)))).Returns(true);
            _centerIsUsedChecker.Setup(n => n.IsUsed(It.IsAny<Guid>())).Returns(false);

        }
        private Center Init(string centerName = "Tabriz",
            int centerID = 2,
            string partName = "Accounting", int partID = 2)
        {
            Center center = new Center(_centerIdValidationCheck.Object,
                              _centerIdDuplicationCheck.Object,
                              _partIdUsedChecker.Object,
                              centerName,
                              centerID);
            Part part = new Part(partName, partID, _partIdValidationChecker.Object);
            center.AddPart(part);
            return center;
        }


        [TestMethod, TestCategory("Center")]
        [ExpectedException(typeof(NullOrWhiteCenterNameException))]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void NullORWhiteSpaceCenterName_Throw_NullOrWhiteCenterNameException(string centerName)
        {
            Init(centerName: centerName);
        }

        [TestMethod, TestCategory("Center")]
        [DataRow("Karaj")]
        [DataRow("Tabriz")]
        public void CenterName_Retrieve(string centerName)
        {
            Center center = Init(centerName: centerName);
            Assert.AreEqual(centerName, center.CenterName);
        }

        [TestMethod, TestCategory("Center")]
        [ExpectedException(typeof(CenterIDIsNotValidException))]

        // [DataRow(null)]
        [DataRow(0)]
        public void NullCenterID_Throw_nullCenterIDException(int centerId)
        {
            _centerIdValidationCheck.Setup(c => c.IsValid(It.IsAny<int>())).Returns(false);
            Init(centerID: centerId);
        }

        [TestMethod, TestCategory("Center")]
        [DataRow(2)]
        public void CenterID_Retrieve(int centerID)
        {
            Center center = Init(centerID: centerID);
            Assert.AreEqual(center.CenterID, centerID);
        }

        [TestMethod, TestCategory("Center")]
        [ExpectedException(typeof(CenterIDDuplicationException))]
        [DataRow(1)]
        public void CenterIDDuplication_throw_CenterIDDuplicationException(int centerId)
        {
            _centerIdDuplicationCheck.Setup(c => c.IsDuplicate(It.IsAny<int>())).Returns(true);

            Init(centerID: centerId);
        }

        [TestMethod, TestCategory("Part")]
        [ExpectedException(typeof(NullOrWhitePartNameException))]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void NullORWhiteSpacePartName_Throw_NullOrWhitePartNameException(string PartName)
        {
            Init(partName: PartName);
        }

        [TestMethod, TestCategory("Part")]
        [DataRow("Sale")]
        public void PartName_Retrieve(string partName)
        {
            Center center = Init(partName: partName);
            Assert.AreEqual(center.Parts.Select(n => n.PartName).FirstOrDefault()?.ToString(), partName);
        }

        [TestMethod, TestCategory("Part")]
        [ExpectedException(typeof(PartIDIsNotValidException))]
        [DataRow(0)]
        [DataRow(null)]
        public void PartIDIsNotValid_Throw_PartIDIsNotValidException(int partId)
        {
            Init(partID: partId);
        }

        [TestMethod, TestCategory("Part")]
        [DataRow(2)]
        public void PartID_Retrieve(int partId)
        {
            Center center = Init(partID: partId);
            Assert.AreEqual(center.Parts.Select(n => n.PartID).FirstOrDefault(), partId);
        }

        [TestMethod, TestCategory("Part")]
        [ExpectedException(typeof(PartIDIsDuplicatedException))]
        [DataRow(1)]
        public void PartIDIsDuplicated_throw_PartIDIsDuplicatedException(int partId)
        {
            Center center = Init();
            Part part = new Part(center.Parts.FirstOrDefault().PartName, center.Parts.FirstOrDefault().PartID, _partIdValidationChecker.Object);
            center.AddPart(part);
        }

        [TestMethod, TestCategory("Part")]
        [ExpectedException(typeof(PartIDIsNotExistException))]
        public void PartIDIsNotExist_throw_PartIDIsNotExistException()
        {
            Center center = Init();
            int partId = center.Parts.Select(n => n.PartID).FirstOrDefault();
            center.DeletePart(_partIdUsedChecker.Object, partId);
            center.DeletePart(_partIdUsedChecker.Object, partId);
        }

        [TestMethod, TestCategory("Part")]
        [ExpectedException(typeof(PartIDIsUsedException))]
        public void PartIDIsUsedExist_throw_PartIDIsUsedExistException()
        {
            Center center = Init();
            Part part = new Part("WareHouse", 5, _partIdValidationChecker.Object);

            center.AddPart(part);
            _partIdUsedChecker.Setup(c => c.IsUsed(It.Is<Guid>(n => n.Equals(part.Id)))).Returns(true);

            center.DeletePart(_partIdUsedChecker.Object, part.PartID);
        }

        [TestMethod, TestCategory("Part")]
        public void Retrieve_DeletePartID()
        {
            Center center = Init();
            int partID = center.Parts.Select(n => n.PartID).FirstOrDefault();
            center.DeletePart(_partIdUsedChecker.Object, partID);
        }

        [TestMethod, TestCategory("DeleteCenter")]
        [ExpectedException(typeof(CenterIsUsedException))]
        public void CenterIsUsed_throw_CenterIsUsedException()
        {
            _centerIsUsedChecker.Setup(n => n.IsUsed(It.IsAny<Guid>())).Returns(true);
            Center center = Init();
            center.CanDeleteCenter(_centerIsUsedChecker.Object);
        }

        [TestMethod, TestCategory("DeleteCenter")]
        public void CenterDelete_retrieve()
        { 
            Center center = Init();
            center.CanDeleteCenter(_centerIsUsedChecker.Object);
        }
    }
}