﻿using Microsoft.Extensions.Configuration;
using ReadModel.Context.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.Programs;
using TicketContext.ReadModel.Query.Contracts.Programs.DataContracts;

namespace TicketContext.ReadModel.Query.Facade.Programs
{
    public class ProgramQueryFacade : IProgramQueryFacade
    {
        private readonly TicketingContext _ticketContext;

        public ProgramQueryFacade(TicketingContext ticketContext)
        {
            _ticketContext = ticketContext;
        }
        public List<ProgramDto> GetAllPrograms()
        {
            List<ProgramDto> programDtos = new List<ProgramDto>();
            programDtos = _ticketContext.Programs.Select(n => new ProgramDto()
            {
                Id = n.Id,
                ProgamName = n.ProgramName,
                ProgramLink = n.ProgramLink,
                Supporters = n.Supporters.Select(m => new ProgramSupporterDto()
                {
                    Id = m.Id,
                    ProgramId = m.Program,
                    ProgramName = n.ProgramName,
                    SupporterpersonID = m.SupporterPersonID,
                    SupporterName = _ticketContext.Persons.Where(p => p.PersonID == m.SupporterPersonID)
                                                          .Select(p => p.Name)
                                                          .First()
                }).ToList()
            }).ToList();
            return programDtos;
        }

        public ProgramDto GetProgramById(Guid id)
        {
            ProgramDto programDtos = new ProgramDto();
            programDtos = _ticketContext.Programs.
                Where(n => n.Id.Equals(id)).Select(n => new ProgramDto()
                {
                    Id = n.Id,
                    ProgamName = n.ProgramName,
                    ProgramLink = n.ProgramLink,
                    Supporters = n.Supporters.Select(m => new ProgramSupporterDto()
                    {
                        Id = m.Id,
                        ProgramId = m.Program,
                        ProgramName = n.ProgramName,
                        SupporterpersonID = m.SupporterPersonID,
                        SupporterName = _ticketContext.Persons.Where(p => p.PersonID == m.SupporterPersonID)
                                                              .Select(p => p.Name)
                                                              .First()
                    }).ToList()
                }).First();
            return programDtos;
        }

        public List<ProgramDto> GetSupporterProgramsList(int supporterCode)
        {
            return _ticketContext.Programs.Where(p => p.Supporters.Any(s => s.SupporterPersonID == supporterCode)).Select(p => new ProgramDto()
            {
                Id = p.Id,
                Supporters = p.Supporters.Select(s => new ProgramSupporterDto()
                {
                    Id = s.Id,
                    ProgramId = s.Program,
                    ProgramName = p.ProgramName,
                    SupporterName = _ticketContext.Persons.Single(pr => pr.PersonID == s.SupporterPersonID).Name,
                    SupporterpersonID = s.SupporterPersonID
                }).ToList(),
                ProgamName = p.ProgramName,
                ProgramLink = p.ProgramLink

            }).ToList();
        }
    }
}
