﻿using Framework.Core.Domain;


namespace TicketContext.Domain.Centers.DomainServices
{
    public interface ICenterIsUsedCheker:IDomainService
    {
        bool IsUsed(Guid Id);
    }
}
