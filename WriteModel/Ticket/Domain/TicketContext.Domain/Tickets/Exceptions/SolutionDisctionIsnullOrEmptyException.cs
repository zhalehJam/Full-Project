﻿using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class SolutionDisctionIsnullOrEmptyException : DomainException
    {
        public override string Message => TicketResource.SolutionDisctionIsnullOrEmptyException;
    }
}
