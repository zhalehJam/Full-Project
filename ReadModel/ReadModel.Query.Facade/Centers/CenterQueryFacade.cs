﻿using Microsoft.Extensions.Configuration;
using ReadModel.Context.Model;
using ReadModel.Query.Contracts.Centers;
using ReadModel.Query.Contracts.Centers.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.ReadModel.Query.Contracts.Centers.DataContracts;
using TicketContext.ReadModel.Query.Contracts.DataContracts;

namespace ReadModel.Query.Facade.Centers
{
    public class CenterQueryFacade : ICenterQueryFacade
    {
        private readonly TicketingContext _ticketContext;
        private readonly IConfiguration _configuration;

        public CenterQueryFacade(TicketingContext ticketContext, IConfiguration configuration)
        {
            _ticketContext = ticketContext;
            _configuration = configuration;
        }

        public List<CenterDto> GetCenters(string centerName = null)
        {
            List<CenterDto> centerDtos = new List<CenterDto>();

            if(centerName != null)
            {
                centerDtos = _ticketContext.Centers.
                    Where(n => n.CenterName.Contains(centerName))
                    .Select(n => new CenterDto()
                    {
                        CenterName = n.CenterName,
                        Center = n.Id,
                        parts = n.Parts.Select(p => new PartDto()
                        {
                            Center = p.Center,
                            Id = p.Id,
                            PartID = p.PartID,
                            PartName = p.PartName
                        }).ToList()
                    }).ToList();

            }
            else
            {
                centerDtos = _ticketContext.Centers.Select(n => new CenterDto()
                {
                    CenterName = n.CenterName,
                    Center = n.Id,
                    CenterID=n.CenterID,
                    parts = n.Parts.Select(p => new PartDto()
                    {
                        Center = p.Center,
                        Id = p.Id,
                        PartID = p.PartID,
                        PartName = p.PartName
                    }).ToList()
                }).ToList();
            }
            return centerDtos;
        }

        public List<CenterDto> GetCentersByfilter(CenterQueryParameter centerQueryParameter)

        {
            var result = _ticketContext.Centers.AsQueryable();
            if(!string.IsNullOrWhiteSpace(centerQueryParameter.CenterName))
                result = result.Where(n => n.CenterName.Contains(centerQueryParameter.CenterName));
            if(centerQueryParameter.CenterID != null && centerQueryParameter.CenterID != 0)
                result = result.Where(n => n.CenterID == centerQueryParameter.CenterID);
            var centerDtos = result.Select(n => new CenterDto()
            {
                CenterName = n.CenterName,
                Center = n.Id,
                CenterID=n.CenterID,
                parts = n.Parts.Select(p => new PartDto()
                {
                    Center = p.Center,
                    Id = p.Id,
                    PartID = p.PartID,
                    PartName = p.PartName
                }).ToList()
            }).ToList();

            if(!string.IsNullOrWhiteSpace(centerQueryParameter.PartName))
            {
                centerDtos = centerDtos.Where(n => n.parts.Where(q => q.PartName.Contains(centerQueryParameter.PartName)).ToList().Count() != 0)
                    .ToList()
                    .Select(n => new CenterDto()
                    {
                        CenterName = n.CenterName,
                        CenterID = n.CenterID,
                        parts = n.parts.Where(q => q.PartName.Contains(centerQueryParameter.PartName)).ToList()
                    })
                    .ToList();
            }
            if(centerQueryParameter.PartID != 0 && centerQueryParameter.PartID != null)
            {
                centerDtos = centerDtos.Where(n => n.parts.Where(q => q.PartID == centerQueryParameter.PartID).ToList().Count() != 0)
                    .ToList()
                    .Select(n => new CenterDto()
                    {
                        CenterName = n.CenterName,
                        CenterID = n.CenterID,
                        parts = n.parts.Where(q => q.PartID == centerQueryParameter.PartID).ToList()
                    })
                    .ToList();
            }
            return centerDtos;
        }
    }
}