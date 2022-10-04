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
        [TestInitialize]
        public void Setup()
        {
            centerIDValidationCheck.Setup(c => c.IsValid(1)).Returns(true);
        }
        private Center Init(string centerName = "Tabriz",
            int centerID= 1)
        {
            return new Center(centerIDValidationCheck.Object,centerName,centerID);
        }


        [TestMethod, TestCategory("Center")]
        [ExpectedException(typeof(NullOrWhiteCenterNameException))]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void NullORWhiteSpaceCenterName_Throw_NullOrWhiteCenterNameException(string centerName)
        {
            Init(centerName:centerName);
        }

        [TestMethod, TestCategory("Center")]
        [DataRow("Karaj")]
        [DataRow("Tabriz")]
        public void CenterName_Retrive(string centerName)
        {
            Center center = Init(centerName:centerName);
            Assert.AreEqual(centerName, center.CenterName);
        }

        [TestMethod, TestCategory("Center")]
        [ExpectedException(typeof(ZeroCenterIDException))]
         
        [DataRow(null)]
        public void NullCenterID_Throw_nullCenterIDException(int centerID)
        {
            Init(centerID:centerID);
        }

        [TestMethod, TestCategory("Center")]
        [DataRow(1)]
        public void CenterID_Retrive(int centerID)
        {
            Center center = Init(centerID:centerID);
            Assert.AreEqual(center.CenterID, centerID);
        }

        [TestMethod,TestCategory("Center")]
        [ExpectedException(typeof(CenterIDIsnotFindInHRException))]
        void CenterIDIsnotFindInHR_throw_CenterIDIsnotFindInHRException(int centerID)
        {
            Center center = Init(centerID: centerID);
        }
    }
}