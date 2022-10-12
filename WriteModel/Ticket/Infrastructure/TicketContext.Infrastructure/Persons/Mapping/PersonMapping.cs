using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketContext.Domain.Persons;

namespace TicketContext.Infrastructure.Persons.Mapping
{
    public class PersonMapping : EntityMappingBase<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            Initial(builder);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.PersonID).HasColumnType(nameof(SqlDbType.Int)).IsRequired();
            builder.Property(x=>x.PartId).HasColumnType(nameof(SqlDbType.UniqueIdentifier)).IsRequired();
        }
    }
}
