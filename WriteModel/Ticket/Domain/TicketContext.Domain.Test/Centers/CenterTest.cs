using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Centers.Exceptions;

namespace TicketContext.Domain.Test.Centers
{
    [TestClass]
    public class CenterTest
    {
        private readonly Mock<ICenterIDValidationCheck> centerIDValidationCheck = new Mock<ICenterIDValidationCheck>();
        private readonly Mock<ICenterIDDuplicationCheck> centerIDDuplicationCheck = new Mock<ICenterIDDuplicationCheck>();
        private readonly Mock<IPartIDValidaionCheker> partIDValidationChecker = new Mock<IPartIDValidaionCheker>();


        [TestInitialize]
        public void Setup()
        {
            centerIDValidationCheck.Setup(c => c.IsValid(It.Is<int>(n=>!n.Equals(0)))).Returns(true);
            centerIDDuplicationCheck.Setup(c => c.IsDuplicate(It.Is<int>(n=>n.Equals(1)))).Returns(true);
            partIDValidationChecker.Setup(c => c.ISValid(It.Is<int>(n => !n.Equals(0)))).Returns(true);


        }
        private Center Init(string centerName = "Tabriz",
            int centerID = 2,
            string partName = "Accounting", int partID = 2)
        {
            Center center = new Center(centerIDValidationCheck.Object,
                              centerIDDuplicationCheck.Object,
                              centerName,
                              centerID);
            Part part = new Part(partName, partID, partIDValidationChecker.Object);
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
        public void CenterName_Retrive(string centerName)
        {
            Center center = Init(centerName: centerName);
            Assert.AreEqual(centerName, center.CenterName);
        }

        [TestMethod, TestCategory("Center")]
        [ExpectedException(typeof(CenterIDIsNotValidException))]

       // [DataRow(null)]
        [DataRow(0)]
        public void NullCenterID_Throw_nullCenterIDException(int centerID)
        {
            Init(centerID: centerID);
        }

        [TestMethod, TestCategory("Center")]
        [DataRow(2)]
        public void CenterID_Retrive(int centerID)
        {
            Center center = Init(centerID: centerID);
            Assert.AreEqual(center.CenterID, centerID);
        }

        [TestMethod, TestCategory("Center")]
        [ExpectedException(typeof(CenterIDDuplicationException))]
        [DataRow(1)]
        public void CenterIDDuplication_throw_CenterIDDuplicationException(int centerID)
        {
            Init(centerID: centerID);
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
        public void PartName_Retrive(string partName)
        {
            Center center = Init(partName: partName);
            Assert.AreEqual(center.Parts.Select(n => n.PartName).FirstOrDefault().ToString(), partName);
        }

        [TestMethod, TestCategory("Part")]
        [ExpectedException(typeof(PartIDIsNotValidException))]
        [DataRow(0)]
        [DataRow(null)]
        public void PartIDIsNotValid_Throw_PartIDIsNotValidException(int PartID)
        {
            Init(partID: PartID);
        }

        [TestMethod, TestCategory("Part")]
        [DataRow(2)]
        public void PartID_Retrive(int partID)
        {
            Center center = Init(partID: partID);
            Assert.AreEqual(center.Parts.Select(n => n.PartID).FirstOrDefault(), partID);
        }

        [TestMethod,TestCategory("Part")]
        [ExpectedException(typeof(PartIDIsDuplicatedException))]
        [DataRow(1)]
        public void PartIDIsDuplicated_throw_PartIDIsDuplicatedException(int partID)
        {
            Center center = Init();
            Part part = new Part(center.Parts.FirstOrDefault().PartName, center.Parts.FirstOrDefault().PartID, partIDValidationChecker.Object);
            center.AddPart(part);
        }

    }
}