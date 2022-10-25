using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Tickets;

namespace TicketContext.Infrastructure.Tickets.Mapping
{
    public class TicketMapping : EntityMappingBase<Ticket>
    {
        public override void Configure(EntityTypeBuilder<Ticket> builder)
        {
            Initial(builder);
            builder.Property(n=>n.SupporterPersonID).IsRequired();
            builder.Property(n => n.PersonID).IsRequired();
            builder.Property(n => n.PersonPartId).IsRequired();
            builder.Property(n=>n.Type).IsRequired();
            builder.Property(n=>n.ErrorType).IsRequired();
            builder.Property(n=>n.ErrorDiscription).IsRequired();
            builder.Property(n => n.SolutionDiscription).IsRequired();
            builder.Property(n=>n.TicketTime).IsRequired();
            builder.Property(n=>n.TicketCondition).IsRequired();
        }
    }
}
