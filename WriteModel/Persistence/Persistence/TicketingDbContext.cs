using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Framework.AssemblyHelper;
using Framework.Core.Persistence;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class TicketingDbContext : DbContextBase
    {
        public TicketingDbContext(DbContextOptions<TicketingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entityMapping = DetectEntityMapping();

            entityMapping.ForEach(a =>
            {
                modelBuilder.ApplyConfiguration(a);
            });
        }


        protected List<dynamic> DetectEntityMapping()
        {
            var assemblyHelper = new AssemblyDiscovery("Ticket*.dll");
            var getType = assemblyHelper.DiscoverTypes<IEntityMapping>("Ticket")
                .Select(Activator.CreateInstance)
                .Cast<dynamic>()
                .ToList();

            return getType;
        }
    }
}
