using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicketContext.Contract.Tickets;
using TicketContext.Domain.Persons;
using TicketContext.Domain.Tickets;
using TicketContext.Domain.Tickets.DomainServices;
using TicketContext.Domain.Tickets.Exceptions;

namespace TicketContext.Domain.Test
{
    [TestClass]
    public class TicketTest
    {
        private readonly Mock<IPersonIDIsValidChecker> _personIDIsValidChecker = new Mock<IPersonIDIsValidChecker>();
        private readonly Mock<IPersonInfo> _personInfo = new Mock<IPersonInfo>();
        private readonly Mock<IProgramIDValidationChecker> _programIDValidationChecker = new Mock<IProgramIDValidationChecker>();
        private readonly Mock<ISupporterPersonIDIsValidChecker> _supporterPersonIDvalidationCheker = new Mock<ISupporterPersonIDIsValidChecker>();

        [TestInitialize]
        public void Setup()
        {
            _personIDIsValidChecker.Setup(n => n.IsValid(It.IsAny<int>())).Returns(true);
            _personInfo.Setup(n => n.GetpersonInfo(It.IsAny<int>())).Returns(new Guid());
            _programIDValidationChecker.Setup(n => n.IsValid(It.IsAny<Guid>())).Returns(true);
            _supporterPersonIDvalidationCheker.Setup(n=>n.IsValid(It.IsAny<int>())).Returns(true);  

        }
        private Ticket Init(int supporterPersonID = 4010019,
                            int personID = 970086,
                            Guid programId = new Guid(),
                            TicketType type = TicketType.Supporting,
                            ErrorType errorType = ErrorType.UserError,
                            string errorDiscription = "description",
                            string solutionDiscription = "Solutiondescription",
                            DateTime ticketTime = new DateTime(),
                            TicketCondition ticketCondition = TicketCondition.Finish)
        {
            Ticket ticket = new Ticket(_personIDIsValidChecker.Object,
                                       _personInfo.Object,
                                       _programIDValidationChecker.Object,
                                       _supporterPersonIDvalidationCheker.Object,
                                       supporterPersonID,
                                       personID,
                                       programId,
                                       type,
                                       errorType,
                                       errorDiscription,
                                       solutionDiscription,
                                       ticketTime,
                                       ticketCondition);
            return ticket;
        }
        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(NullOrZiroPersonIDException))]
        [DataRow(null)]
        [DataRow(0)]
        public void NullOrWhitePersonID_Throw_NullOrWhitePersonIDException(int personID)
        {
            Init(personID: personID);
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidPersonIDException))]
        public void InvalidPersonID_throw_InvalidPersonIDException()
        {
            _personIDIsValidChecker.Setup(n => n.IsValid(It.IsAny<int>())).Returns(false);
            Init();
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidProgramIDException))]
        public void InvalidProgramID_throw_InvalidProgramIDException()
        {
            _programIDValidationChecker.Setup(n => n.IsValid(It.IsAny<Guid>())).Returns(false);
            Init();
        }

        [TestMethod,TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidSupporterPersonIDException))]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(0)]
        [DataRow(921454)]
        public void InvalidSupporterPersonID_throw_InvalidSupporterPersonIDException(int supporterPersonID)
        {
            _supporterPersonIDvalidationCheker.Setup(n => n.IsValid(It.IsAny<int>())).Returns(false);

            Init(supporterPersonID: supporterPersonID);
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(ErrorDisctionIsnullOrEmptyException))]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("    ")]
        public void ErrorDisctionIsnullOrEmpty_throw_ErrorDisctionIsnullOrEmptyException(string errorDiscription)
        {
            Init(errorDiscription: errorDiscription);
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(SolutionDisctionIsnullOrEmptyException))]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("    ")]
        public void SolutionDisctionIsnullOrEmpty_throw_SolutionDisctionIsnullOrEmptyException(string solutionDiscription)
        {
            Init(solutionDiscription: solutionDiscription);
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(TicketDateTimeIsNotValidException))]
        public void TicketDateTimeIsNotValid_throw_TicketDateTimeIsNotValidException()
        {
            DateTime dateTime = DateTime.Now.AddMilliseconds(1);
            Init(ticketTime: dateTime);
        }


        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidTicketTypeExcption))]
        public void InvalidTicketType_throw_InvalidTicketTypeExcption()
        {
            TicketType ticketType = new TicketType();
            Init(type:ticketType);
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidTicketConditionExcption))]
        public void InvalidTicketCondition_throw_InvalidTicketConditionExcption()
        {
            TicketCondition ticketCondition = new TicketCondition();
            Init(ticketCondition:ticketCondition);
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidErrorTypeExcption))]
        public void InvalidErrorType_throw_InvalidErrorTypeExcption()
        {
            ErrorType errorType = new ErrorType();
            Init(errorType:errorType);
        }

        [TestMethod, TestCategory("Ticket")]
        [DataRow(970428)]
        public void TicketPersonID_Retrive(int personID)
        {
            Ticket ticket = Init(personID: personID);
            Assert.AreEqual(ticket.PersonID, personID);
        }
        [TestMethod, TestCategory("Ticket")]
        public void TicketPersonPartId_Retrive()
        {
            Guid guid = Guid.NewGuid();
            _personInfo.Setup(n => n.GetpersonInfo(It.IsAny<int>())).Returns(guid);
            Ticket ticket = Init();
            Assert.AreEqual(ticket.PersonPartId, guid);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketProgramId_Retrive()
        {
            Guid guid = Guid.NewGuid();
            Ticket ticket = Init(programId: guid);
            Assert.AreEqual(ticket.ProgramId, guid);
        }


        [TestMethod, TestCategory("Ticket")]
        public void TicketType_Retrive()
        {
            TicketType ticketType = (TicketType)1;
            Ticket ticket = Init(type:ticketType);
            Assert.AreEqual(ticket.Type, ticketType);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketErrorType_Retrive()
        {
            ErrorType errorType = (ErrorType)2;
            Ticket ticket = Init(errorType: errorType);
            Assert.AreEqual(ticket.ErrorType, errorType);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketErrorDescription_Retrive()
        {
            string description = "Describe";
            Ticket ticket = Init(errorDiscription:description);
            Assert.AreEqual(ticket.ErrorDiscription, description);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketSolutionDescription_Retrive()
        {
            string description = "SolutionDescribe";
            Ticket ticket = Init(solutionDiscription: description);
            Assert.AreEqual(ticket.SolutionDiscription, description);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketDateTime_Retrive()
        {
            DateTime dateTime = DateTime.Now;
            Ticket ticket = Init(ticketTime: dateTime);
            Assert.AreEqual(ticket.TicketTime, dateTime);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketCondition_Retrive()
        {
            TicketCondition ticketCondition = (TicketCondition)2;
            Ticket ticket = Init(ticketCondition: ticketCondition);
            Assert.AreEqual(ticket.TicketCondition, ticketCondition);
        }
    }
}
