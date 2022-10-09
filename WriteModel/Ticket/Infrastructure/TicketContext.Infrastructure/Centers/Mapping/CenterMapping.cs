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

namespace TicketContext.Infrastructure.Centers.Mapping
{
    public class CenterMapping : EntityMappingBase<Center>
    {
        public override void Configure(EntityTypeBuilder<Center> builder)
        {
            Initial(builder);
            builder.Property(x => x.CenterID).HasColumnType(nameof(SqlDbType.Int)).IsRequired();
            builder.Property(x => x.CenterName).HasMaxLength(100).IsRequired();
            builder.OwnsMany(n => n.Parts,
                map =>
                {
                    map.Property<Guid>("Id")
                       .HasColumnType(nameof(SqlDbType.UniqueIdentifier))
                       .IsRequired().ValueGeneratedNever();
                    map.Property<string>("PartName")
                       .HasMaxLength(100)
                       .IsRequired();
                    map.Property<int>("PartID")
                       .HasColumnType(nameof(SqlDbType.Int))
                       .IsRequired();
                    map.WithOwner().HasForeignKey("Center");
                    map.ToTable(typeof(Part).Name, typeof(Part).Namespace?.Split(".")[0])
                       .HasKey("Id");
                });
        }
    }
}
