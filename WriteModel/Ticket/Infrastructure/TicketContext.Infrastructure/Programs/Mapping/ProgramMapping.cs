using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Programs;

namespace TicketContext.Infrastructure.Programs.Mapping
{
    public class ProgramMapping : EntityMappingBase<Program>
    {
        public override void Configure(EntityTypeBuilder<Program> builder)
        {
            Initial(builder);
            builder.Property(n => n.ProgramName).HasMaxLength(200).IsRequired();
            builder.Property(n=>n.ProgramLink).IsRequired();
        }
    }
}
