using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Centers;
using TicketContext.Domain.Programs;

namespace TicketContext.Infrastructure.Programs.Mapping
{
    public class ProgramMapping : EntityMappingBase<Program>
    {
        public override void Configure(EntityTypeBuilder<Program> builder)
        {
            Initial(builder);
            builder.Property(n => n.ProgramName).HasMaxLength(200).IsRequired();
            builder.Property(n => n.ProgramLink).IsRequired();
            builder.OwnsMany(n => n.ProgramSupporters,
                map =>
                {
                    map.Property<Guid>("Id")
                       .HasColumnType(nameof(SqlDbType.UniqueIdentifier))
                       .IsRequired().ValueGeneratedNever();
                    map.Property(n => n.SupporterPersonID)
                       .HasColumnType(nameof(SqlDbType.Int))
                       .IsRequired();
                    map.WithOwner().HasForeignKey("Program");
                    map.ToTable(typeof(ProgramSupporter).Name, typeof(ProgramSupporter).Namespace?.Split(".")[0])
                       .HasKey("Id");
                });
        }
    }
}
