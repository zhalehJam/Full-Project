using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Centers.Exceptions;
using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Programs;
using TicketContext.Domain.Programs.DomainServices;
using TicketContext.Domain.Programs.Exceptions;
using Program = TicketContext.Domain.Programs.Program;

namespace TicketContext.Domain.Test
{
    [TestClass]
    public class ProgramTest
    {
        private readonly Mock<IProgramNameDuplicateChecker> _programNameDuplicateChecker = new Mock<IProgramNameDuplicateChecker>();

        [TestInitialize]
        public void Setup()
        {
            _programNameDuplicateChecker.Setup(c => c.IsDuplicated(It.Is<string>(n => n.Equals("Ticketing")))).Returns(true) ;
            

        }
        private Program Init(string programName="Sale&Accounting",string link="")
        {
            Program program = new Program(programName,
                                          link,
                                          _programNameDuplicateChecker.Object);
            return program;
        }

        [TestMethod, TestCategory("Program")]
        [ExpectedException(typeof(NullOrWhiteProgramNameException))]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void NullORWhiteSpaceProgramName_Throw_NullOrWhiteProgramNameException(string programName)
        {
            Init(programName:programName);
        }

        [TestMethod,TestCategory("Program")]
        [ExpectedException(typeof(ProgramNameIsDupliateException))]
        [DataRow("Ticketing")]
        public void ProgramNameIsDupliate_throw_ProgramNameIsDupliateException(string programName)
        {
            Init(programName: programName);
        }

        [TestMethod, TestCategory("Program")]
        [DataRow("Accounting")]
        public void Retrive_ProgramName (string programName)
        {
            Program program = Init(programName:programName);
            Assert.AreEqual(program.ProgramName, programName);
        }

        [TestMethod, TestCategory("Program")]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("Programlink")]
        public void Retrive_UpdateProgramLink(string link)
        {
            Program program= Init();
            program.UpdateProgramLink(link);
            Assert.AreEqual(program.ProgramLink,link);
        }
    }
}
