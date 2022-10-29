using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReadModel.Context.Model
{
    public partial class TicketingContext : DbContext
    {
        public TicketingContext()
        { }

        public TicketingContext(DbContextOptions<TicketingContext> dbContextOptions) : base(dbContextOptions)
        { }
        public virtual DbSet<Center> Centers { get; set; } = null!;
        public virtual DbSet<Part> Parts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if(!dbContextOptionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                dbContextOptionsBuilder.UseSqlServer("Server =.,1433; Database = TicketingDeveloper; user id=sa;password=123; ");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Center>(entity =>
            {
                entity.ToTable("Center", "TicketContext");
                entity.Property(n => n.Id).ValueGeneratedNever();
                entity.Property(n => n.CenterName);
                entity.Property(n => n.CenterID);
            }
            );

            modelBuilder.Entity<Part>((Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Part>>)(n =>
            {
                n.ToTable<Part>("Part", "TicketContext");
                n.Property(n => n.Id).ValueGeneratedNever();
                n.Property<string>(n => n.PartName);
                n.Property<int>(n => n.PartID);
                n.HasOne<Center>(d => d.centers)
                  .WithMany(d => d.Parts)
                  .HasForeignKey((System.Linq.Expressions.Expression<Func<Part, object?>>)(d => d.Center));
            }));

            //modelBuilder.HasSequence
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
