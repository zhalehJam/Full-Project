using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Contract.Tickets;
using TicketContext.Domain.Tickets.DomainServices;
using TicketContext.Domain.Tickets.Exceptions;

namespace TicketContext.Domain.Tickets
{
    public class Ticket : EntityBase, IAggregateRoot
    {
        private   IPersonIDIsValidChecker _personIDIsValidChecker;
        private   IPersonInfo _personInfo;
        private   IProgramIDValidationChecker _programIDIsValidChecker;
        private   ISupporterPersonIDIsValidChecker _supporterPersonIDIsValidChecker;

        public int PersonID { get; private set; }
        public Guid PersonPartId { get; private set; }
        public Guid ProgramId { get; private set; }
        public ErrorType ErrorType { get; private set; }
        public TicketType Type { get; private set; }
        public string ErrorDiscription { get; private set; }
        public string SolutionDiscription { get; private set; }
        public DateTime TicketTime { get; private set; }
        public TicketCondition TicketCondition { get; private set; }
        public int SupporterPersonID { get; private set; }

        public Ticket(IPersonIDIsValidChecker personIDIsValidChecker,
                      IPersonInfo personInfo,
                      IProgramIDValidationChecker programIDIsValidChecker,
                      ISupporterPersonIDIsValidChecker supporterPersonIDIsValidChecker,
                      int supporterPersonID,
                      int personID,
                      Guid programId,
                      TicketType type,
                      ErrorType errorType,
                      string errorDiscription,
                      string solutionDiscription,
                      DateTime ticketTime,
                      TicketCondition ticketCondition
                      )
        {
            _personIDIsValidChecker = personIDIsValidChecker;
            _personInfo = personInfo;
            _programIDIsValidChecker = programIDIsValidChecker;
            _supporterPersonIDIsValidChecker = supporterPersonIDIsValidChecker;
            SetSupporterPersonID(supporterPersonID);
            SetTicketType(type);
            SetErrorType(errorType);
            SetTicketCondition(ticketCondition);
            SetErrorDiscription(errorDiscription);
            SetSolutionDescription(solutionDiscription);
            SetTicketDateTime(ticketTime);
            SetProgramId(programId);
            SetPersonInfo(personID);
        }

        protected Ticket()
        { }

        private void SetTicketCondition(TicketCondition ticketCondition)
        {
            if(!Enum.IsDefined(typeof(TicketCondition), ticketCondition))
                throw new InvalidTicketConditionExcption();
            TicketCondition = ticketCondition;
        }

        private void SetSupporterPersonID(int supporterPersonID)
        {
            if(!_supporterPersonIDIsValidChecker.IsValid(supporterPersonID))
                throw new InvalidSupporterPersonIDException();
            SupporterPersonID = supporterPersonID;
        }

        private void SetErrorType(ErrorType errorType)
        {
            if(!Enum.IsDefined(typeof(ErrorType), errorType))
                throw new InvalidErrorTypeExcption();
            ErrorType = errorType;
        }

        private void SetTicketType(TicketType type)
        {
            if(!Enum.IsDefined(typeof(TicketType), type))
                throw new InvalidTicketTypeExcption();
            Type = type;
        }

        private void SetTicketDateTime(DateTime ticketTime)
        {
            if(ticketTime > DateTime.Now)
                throw new TicketDateTimeIsNotValidException();
            TicketTime = ticketTime;
        }

        private void SetSolutionDescription(string solutionDiscription)
        {
            if(string.IsNullOrWhiteSpace(solutionDiscription))
                throw new SolutionDisctionIsnullOrEmptyException();
            SolutionDiscription = solutionDiscription;
        }

        private void SetErrorDiscription(string errorDiscription)
        {
            if(string.IsNullOrWhiteSpace(errorDiscription))
                throw new ErrorDisctionIsnullOrEmptyException();
            ErrorDiscription = errorDiscription;
        }

        private void SetProgramId(Guid programID)
        {
            if(!_programIDIsValidChecker.IsValid(programID))
                throw new InvalidProgramIDException();
            ProgramId = programID;
        }

        private void SetPersonInfo(int personID)
        {
            if(personID == 0)
                throw new NullOrZiroPersonIDException();
            if(!_personIDIsValidChecker.IsValid(personID))
                throw new InvalidPersonIDException();
            PersonPartId = _personInfo.GetpersonInfo(personID);
            PersonID = personID;
        }

        public void UpdateTicketInfo(IPersonIDIsValidChecker personIDIsValidChecker,
                                     IPersonInfo personInfo,
                                     IProgramIDValidationChecker programIDIsValidChecker,
                                     int supporterThatEditPersonID,
                                     int personID,
                                     Guid programId,
                                     TicketType type,
                                     ErrorType errorType,
                                     string errorDiscription,
                                     string solutionDiscription,
                                     DateTime ticketTime,
                                     TicketCondition ticketCondition)
        {
            CheckTicketCanUpdate(supporterThatEditPersonID);

            _personIDIsValidChecker = personIDIsValidChecker;
            _personInfo = personInfo;
            _programIDIsValidChecker = programIDIsValidChecker;
            SetTicketType(type);
            SetErrorType(errorType);
            SetTicketCondition(ticketCondition);
            SetErrorDiscription(errorDiscription);
            SetSolutionDescription(solutionDiscription);
            SetTicketDateTime(ticketTime);
            SetProgramId(programId);
            SetPersonInfo(personID);

        }

        private void CheckTicketCanUpdate(int supporterThatEditPersonID)
        {

            if(TicketCondition.Equals(TicketCondition.Finish))
                throw new TheCompetedTicketCannotUpdateEception();
            if(SupporterPersonID != supporterThatEditPersonID)
                throw new TicketDidNotCeateByCurrentSupporerException();
        }
    }
}
