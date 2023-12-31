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
        private readonly Mock<IPersonIDIsValidChecker> _personIDIsValidChecker = new();
        private readonly Mock<IPersonInfo> _personInfo = new();
        private readonly Mock<IProgramIDValidationChecker> _programIDValidationChecker = new();
        private readonly Mock<ISupporterPersonIDIsValidChecker> _supporterPersonIDvalidationChecker = new();

        [TestInitialize]
        public void Setup()
        {
            _personIDIsValidChecker.Setup(n => n.IsValid(It.IsAny<int>())).Returns(true);
            _personInfo.Setup(n => n.GetPersonInfo(It.IsAny<int>())).Returns(new Guid());
            _programIDValidationChecker.Setup(n => n.IsValid(It.IsAny<Guid>())).Returns(true);
            _supporterPersonIDvalidationChecker.Setup(n => n.IsValid(It.IsAny<int>())).Returns(true);

        }
        private Ticket Init(int supporterPersonID = 4010019,
                            int personID = 970086,
                            Guid programId = new Guid(),
                            TicketType type = TicketType.Supporting,
                            ErrorType errorType = ErrorType.UserError,
                            string ErrorDiscription = "description",
                            string solutionDiscription = "SolutionDiscription",
                            DateTime ticketTime = new DateTime(),
                            TicketCondition ticketCondition = TicketCondition.OnGoing)
        {

            Ticket ticket = new Ticket(_personIDIsValidChecker.Object,
                                       _personInfo.Object,
                                       _programIDValidationChecker.Object,
                                       _supporterPersonIDvalidationChecker.Object,
                                       supporterPersonID,
                                       personID,
                                       programId,
                                       type,
                                       errorType,
                                       ErrorDiscription,
                                       solutionDiscription,
                                       ticketTime,
                                       ticketCondition);
            return ticket;
        }

        private Ticket Update(Ticket ticket,
            int supporterPersonID = 4010019,
                            int personID = 970086,
                            Guid programId = new Guid(),
                            TicketType type = TicketType.Developing,
                            ErrorType errorType = ErrorType.SystemError,
                            string ErrorDiscription = "description2",
                            string solutionDiscription = "SolutionDiscription2",
                            DateTime ticketTime = new DateTime(),
                            TicketCondition ticketCondition = TicketCondition.Finish)
        {
            ticketTime = DateTime.Now;
            ticket.UpdateTicketInfo(_personIDIsValidChecker.Object,
                                    _personInfo.Object,
                                    _programIDValidationChecker.Object,
                                    supporterPersonID,
                                    personID,
                                    programId,
                                    type,
                                    errorType,
                                    ErrorDiscription,
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

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidSupporterPersonIDException))]
       
        [DataRow(0)]
        [DataRow(921454)]
        public void InvalidSupporterPersonID_throw_InvalidSupporterPersonIDException(int supporterPersonID)
        {
            _supporterPersonIDvalidationChecker.Setup(n => n.IsValid(It.IsAny<int>())).Returns(false);

            Init(supporterPersonID: supporterPersonID);
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(ErrorDisctionIsnullOrEmptyException))]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("    ")]
        public void ErrorDisctionIsnullOrEmpty_throw_ErrorDisctionIsnullOrEmptyException(string ErrorDiscription)
        {
            Init(ErrorDiscription: ErrorDiscription);
        }

        //[TestMethod, TestCategory("Ticket")]
        //[ExpectedException(typeof(SolutionDisctionIsnullOrEmptyException))]
        //[DataRow(null)]
        //[DataRow("")]
        //[DataRow("    ")]
        //public void SolutionDisctionIsnullOrEmpty_throw_SolutionDisctionIsnullOrEmptyException(string solutionDiscription)
        //{
        //    Init(solutionDiscription: solutionDiscription);
        //}

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(TicketDateTimeIsNotValidException))]
        public void TicketDateTimeIsNotValid_throw_TicketDateTimeIsNotValidException()
        {
            DateTime dateTime = DateTime.Now.AddMilliseconds(1);
            Init(ticketTime: dateTime);
        }


        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidTicketTypeExcption))]
        public void InvalidTicketType_throw_InvalidTicketTypeException()
        {
            TicketType ticketType = new TicketType();
            Init(type: ticketType);
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidTicketConditionExcption))]
        public void InvalidTicketCondition_throw_InvalidTicketConditionException()
        {
            TicketCondition ticketCondition = new TicketCondition();
            Init(ticketCondition: ticketCondition);
        }

        [TestMethod, TestCategory("Ticket")]
        [ExpectedException(typeof(InvalidErrorTypeExcption))]
        public void InvalidErrorType_throw_InvalidErrorTypeException()
        {
            ErrorType errorType = new ErrorType();
            Init(errorType: errorType);
        }

        [TestMethod, TestCategory("Ticket")]
        [DataRow(970428)]
        public void TicketPersonID_Retrieve(int personID)
        {
            Ticket ticket = Init(personID: personID);
            Assert.AreEqual(ticket.PersonID, personID);
        }
        [TestMethod, TestCategory("Ticket")]
        public void TicketPersonPartId_Retrieve()
        {
            Guid guid = Guid.NewGuid();
            _personInfo.Setup(n => n.GetPersonInfo(It.IsAny<int>())).Returns(guid);
            Ticket ticket = Init();
            Assert.AreEqual(ticket.PersonPartId, guid);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketProgramId_Retrieve()
        {
            Guid guid = Guid.NewGuid();
            Ticket ticket = Init(programId: guid);
            Assert.AreEqual(ticket.ProgramId, guid);
        }


        [TestMethod, TestCategory("Ticket")]
        public void TicketType_Retrieve()
        {
            TicketType ticketType = (TicketType)1;
            Ticket ticket = Init(type: ticketType);
            Assert.AreEqual(ticket.Type, ticketType);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketErrorType_Retrieve()
        {
            ErrorType errorType = (ErrorType)2;
            Ticket ticket = Init(errorType: errorType);
            Assert.AreEqual(ticket.ErrorType, errorType);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketErrorDescription_Retrieve()
        {
            string description = "Describe";
            Ticket ticket = Init(ErrorDiscription: description);
            Assert.AreEqual(ticket.ErrorDiscription, description);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketSolutionDescription_Retrieve()
        {
            string description = "SolutionDescribe";
            Ticket ticket = Init(solutionDiscription: description);
            Assert.AreEqual(ticket.SolutionDiscription, description);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketDateTime_Retrieve()
        {
            DateTime dateTime = DateTime.Now;
            Ticket ticket = Init(ticketTime: dateTime);
            Assert.AreEqual(ticket.TicketTime, dateTime);
        }

        [TestMethod, TestCategory("Ticket")]
        public void TicketCondition_Retrieve()
        {
            TicketCondition ticketCondition = (TicketCondition)2;
            Ticket ticket = Init(ticketCondition: ticketCondition);
            Assert.AreEqual(ticket.TicketCondition, ticketCondition);
        }
         
        [TestMethod, TestCategory("Ticket Update")]
        [ExpectedException(typeof(TheCompetedTicketCannotUpdateEception))]
        public void TheCompetedTicketCannotUpdate_throw_TheCompetedTicketCannotUpdateEception()
        {
            Ticket ticket = Init(ticketCondition: TicketCondition.Finish);
            Update(ticket, ticketCondition: TicketCondition.Finish);

        }

        [TestMethod, TestCategory("Ticket Update")]
        [ExpectedException(typeof(TicketDidNotCeateByCurrentSupporerException))]
        public void TicketDidNotCreateByCurrentSupporter_Throw()
        {
            Ticket ticket = Init();
            Update(ticket, supporterPersonID: ticket.SupporterPersonID + 1);
        }

        [TestMethod, TestCategory("Ticket Update")]
        public void TicketUpdate_retrieve()
        {
            Ticket ticket = Init();
            Ticket ticket1 = Update(ticket);
            Assert.AreEqual(ticket, ticket1);
        }

        [TestMethod, TestCategory("Delete Ticket")]
        [ExpectedException(typeof(TicketCannotDeletetException))]
        public void TicketCannotDeleted_Throw_TicketCannotDeletedException()
        {
            Ticket ticket = Init();
            ticket.CheckTicketCanDelete(ticket.SupporterPersonID + 1);
        }

        [TestMethod, TestCategory("Delete Ticket")]
        public void DeleteTicket_Retrieve()
        {
            Ticket ticket = Init();
            ticket.CheckTicketCanDelete(ticket.SupporterPersonID);
        }

    }

}
