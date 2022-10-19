﻿using Microsoft.VisualStudio.TestPlatform.TestHost;
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
        private readonly Mock<IValidSupporterPersonIDChecker> _validSupporterPersonIDChecker = new Mock<IValidSupporterPersonIDChecker>();


        [TestInitialize]
        public void Setup()
        {
            _programNameDuplicateChecker.Setup(c => c.IsDuplicated(It.Is<string>(n => n.Equals("Ticketing")))).Returns(true);
            _validSupporterPersonIDChecker.Setup(n => n.Isvalid(It.Is<Int32>(n => (n.Equals(970086)||n.Equals(970428))))).Returns(true);

        }
        private Program Init(string programName = "Sale&Accounting", string link = "")
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
            Init(programName: programName);
        }

        [TestMethod, TestCategory("Program")]
        [ExpectedException(typeof(ProgramNameIsDupliateException))]
        [DataRow("Ticketing")]
        public void ProgramNameIsDupliate_throw_ProgramNameIsDupliateException(string programName)
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
            ProgramSupporter programSupporter = new ProgramSupporter(supporterID, _validSupporterPersonIDChecker.Object);
            program.AddProgramSupporter(programSupporter);
        }

        [TestMethod,TestCategory("ProgramSupporters")]
        [ExpectedException(typeof(DuplicateProgramSupporerIDException))]
        [DataRow(970086)]
        public void DuplicateProgramSupporerID_throw_DuplicateProgramSupporerIDException(Int32 supporterID)
        {
           Program program= Init();
            ProgramSupporter programSupporter = new ProgramSupporter(supporterID, _validSupporterPersonIDChecker.Object);
            program.AddProgramSupporter(programSupporter);
            program.AddProgramSupporter(programSupporter);
        }

        [TestMethod, TestCategory("ProgramSupporters")]
        [DataRow(970086)]
        public void Retrive_ProgramSupporter(Int32 supporterID)
        {
            Program program = Init();
            ProgramSupporter programSupporter = new ProgramSupporter(supporterID, _validSupporterPersonIDChecker.Object);
            program.AddProgramSupporter(programSupporter);
            Assert.IsTrue(program.ProgramSupporters.Any(n => n.SupporterPersonID == supporterID));
        }

        [TestMethod, TestCategory("ProgramSupporters")]
        [DataRow(970086,970428)]
        public void Retrive_ProgramtwoSupporter(Int32 supporterID1, Int32 supporterID2)
        {
            Program program = Init();
            ProgramSupporter programSupporter1 = new ProgramSupporter(supporterID1, _validSupporterPersonIDChecker.Object);
            ProgramSupporter programSupporter2 = new ProgramSupporter(supporterID2, _validSupporterPersonIDChecker.Object);

            program.AddProgramSupporter(programSupporter1);
            program.AddProgramSupporter(programSupporter2);

            Assert.IsTrue(program.ProgramSupporters.Any(n =>n.SupporterPersonID == supporterID1)
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
                                                                      _validSupporterPersonIDChecker.Object);
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
                                                                      _validSupporterPersonIDChecker.Object);
            program1.AddProgramSupporter(programSupporter);
            program2.AddProgramSupporter(programSupporter);


            Assert.IsTrue(program1.ProgramSupporters.Any(n => n.SupporterPersonID == supporterID) 
                       && program2.ProgramSupporters.Any(n => n.SupporterPersonID == supporterID));
        }
    }
}
