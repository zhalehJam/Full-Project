﻿using Framework.Core.Domain;
using TicketContext.Domain.Persons;

namespace TicketContext.Domain.Tickets.DomainServices
{
    public interface IPersonInfo:IDomainService
    {
        Guid GetPersonInfo(int personID);
    }
}
