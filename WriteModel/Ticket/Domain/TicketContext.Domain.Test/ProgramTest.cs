using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Programs.DomainServices;
using TicketContext.Domain.Programs.Exceptions;
using Program = TicketContext.Domain.Programs.Program;

namespace TicketContext.Domain.Test
{
    [TestClass]
    public class ProgramTest
    {
        private readonly Mock<IProgramNameDuplicateChecker> _programNameDuplicateChecker = new();
        private readonly Mock<IValidSupporterPersonIDChecker> _validSupporterPersonIdChecker = new();
        private readonly Mock<IProgramHasTicketChecker> _programHasTicketChecker = new();

        [TestInitialize]
        public void Setup()
        {
            _programNameDuplicateChecker.Setup(c => c.IsDuplicated(It.Is<string>(n => n.Equals("Ticketing")))).Returns(true);
            _validSupporterPersonIdChecker.Setup(n => n.Isvalid(It.Is<Int32>(n => (n.Equals(970086) || n.Equals(970428))))).Returns(true);
            _programHasTicketChecker.Setup(n => n.HasTicket(It.IsAny<Guid>())).Returns(false);

        }
        private Program Init(string programName = "Sale&Accounting", string link = "")
        {
            Program program = new Program(programName,
                                          link,
                                          _programNameDuplicateChecker.Object,
                                          _programHasTicketChecker.Object);
            return program;
        }

        [TestMethod, TestCategory("Program")]
        [ExpectedException(typeof(NullOrWhiteProgramNameException))]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void NullORWhiteSpaceProgramName_Throw_NullOrWhiteProgramNameException(string programName)
        {
            Init(programName: programName);
        }

        [TestMethod, TestCategory("Program")]
        [ExpectedException(typeof(ProgramNameIsDuplicateException))]
        [DataRow("Ticketing")]
        public void ProgramNameIsDupliate_throw_ProgramNameIsDuplicateException(string programName)
        {
            Init(programName: programName);
        }

        [TestMethod, TestCategory("Program")]
        [DataRow("Accounting")]
        public void Retrive_ProgramName(string programName)
        {
            Program program = Init(programName: programName);
            Assert.AreEqual(program.ProgramName, programName);
        }

        [TestMethod, TestCategory("Program")]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("Programlink")]
        public void Retrive_UpdateProgramLink(string link)
        {
            Program program = Init();
            program.UpdateProgramLink(link);
            Assert.AreEqual(program.ProgramLink, link);
        }
        [TestMethod, TestCategory("ProgramSupporters")]
        [ExpectedException(typeof(SupporterIdIsNotValidException))]
        [DataRow(0)]
        [DataRow(null)]
        [DataRow(970098)]
        public void SupporterIdIsNotValid_throw_SupporterIdIsNotValidException(Int32 supporterID)
        {
            Program program = Init();
            ProgramSupporter programSupporter = new ProgramSupporter(supporterID, _validSupporterPersonIdChecker.Object);
            program.AddProgramSupporter(programSupporter);
        }

        [TestMethod, TestCategory("ProgramSupporters")]
        [ExpectedException(typeof(DuplicateProgramSupporerIDException))]
        [DataRow(970086)]
        public void DuplicateProgramSupporerID_throw_DuplicateProgramSupporerIDException(Int32 supporterID)
        {
            Program program = Init();
            ProgramSupporter programSupporter = new ProgramSupporter(supporterID, _validSupporterPersonIdChecker.Object);
            program.AddProgramSupporter(programSupporter);
            program.AddProgramSupporter(programSupporter);
        }

        [TestMethod, TestCategory("ProgramSupporters")]
        [DataRow(970086)]
        public void Retrive_ProgramSupporter(Int32 supporterID)
        {
            Program program = Init();
            ProgramSupporter programSupporter = new ProgramSupporter(supporterID, _validSupporterPersonIdChecker.Object);
            program.AddProgramSupporter(programSupporter);
            Assert.IsTrue(program.ProgramSupporters.Any(n => n.SupporterPersonID == supporterID));
        }

        [TestMethod, TestCategory("ProgramSupporters")]
        [DataRow(970086, 970428)]
        public void Retrive_ProgramtwoSupporter(Int32 supporterID1, Int32 supporterID2)
        {
            Program program = Init();
            ProgramSupporter programSupporter1 = new ProgramSupporter(supporterID1, _validSupporterPersonIdChecker.Object);
            ProgramSupporter programSupporter2 = new ProgramSupporter(supporterID2, _validSupporterPersonIdChecker.Object);

            program.AddProgramSupporter(programSupporter1);
            program.AddProgramSupporter(programSupporter2);

            Assert.IsTrue(program.ProgramSupporters.Any(n => n.SupporterPersonID == supporterID1)
                       && program.ProgramSupporters.Any(n => n.SupporterPersonID == supporterID2));
        }

        [TestMethod, TestCategory("ProgramSupporters")]
        [ExpectedException(typeof(InvalidProgramSupporterPersonIdException))]
        [DataRow(970086)]
        public void InvalidProgramSupporterPersonId_throw_InvalidProgramSupporterPersonIdException(Int32 supporterID)
        {
            Program program = Init();
            program.DeleteProgramSupporter(supporterID);
        }

        [TestMethod, TestCategory("ProgramSupporters")]
        [DataRow(970086)]
        public void Retrive_DeleteProgramSupporter(Int32 supporterID)
        {
            Program program = Init();
            ProgramSupporter programSupporter1 = new ProgramSupporter(supporterID,
                                                                      _validSupporterPersonIdChecker.Object);
            program.AddProgramSupporter(programSupporter1);
            program.DeleteProgramSupporter(supporterID);
            Assert.IsTrue(!program.ProgramSupporters.Any(n => n.SupporterPersonID == supporterID));
        }

        [TestMethod, TestCategory("ProgramSupporters")]
        [DataRow(970086)]
        public void Retrive_DiferetProgramSupporter(Int32 supporterID)
        {
            Program program1 = Init();
            Program program2 = Init();

            ProgramSupporter programSupporter = new ProgramSupporter(supporterID,
                                                                      _validSupporterPersonIdChecker.Object);
            program1.AddProgramSupporter(programSupporter);
            program2.AddProgramSupporter(programSupporter);


            Assert.IsTrue(program1.ProgramSupporters.Any(n => n.SupporterPersonID == supporterID)
                       && program2.ProgramSupporters.Any(n => n.SupporterPersonID == supporterID));
        }

        [TestMethod, TestCategory("DeleteProgram")]
        [ExpectedException(typeof(CannotDeleteProgramException))]
        public void CannotDeleteProgram_throw_CannotDeleteProgramException()
        {
            _programHasTicketChecker.Setup(n => n.HasTicket(It.IsAny<Guid>())).Returns(true);
            Program program = Init();
            program.CanDeleteProgram(_programHasTicketChecker.Object);
        }

        [TestMethod, TestCategory("DeleteProgram")]
        public void DeleteProgram_Retrive()
        {
            Program program = Init();
            program.CanDeleteProgram(_programHasTicketChecker.Object);
            Assert.IsTrue(true);
        }
    }
}
