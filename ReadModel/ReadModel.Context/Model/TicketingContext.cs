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
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<Program> Programs { get; set; } = null!;
        public virtual DbSet<ProgramSupporter> ProgramSupporters { get; set; } = null!;
        public virtual DbSet<Ticket> Ticket { get; set; } = null!;

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
            });

            modelBuilder.Entity<Part>(n =>
            {
                n.ToTable<Part>("Part", "TicketContext");
                n.Property(n => n.Id).ValueGeneratedNever();
                n.Property<string>(n => n.PartName);
                n.Property<int>(n => n.PartID);
                n.HasOne<Center>(d => d.centers)
                  .WithMany(d => d.Parts)
                  .HasForeignKey(d => d.Center);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person", "TicketContext");
                entity.Property(n => n.Id).ValueGeneratedNever();
                entity.Property(n => n.PersonID);
                entity.Property(n => n. Name);
                entity.Property(n => n.PartId);
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.ToTable<Program>("Program", "TicketContext");
                entity.Property(n => n.Id).ValueGeneratedNever();
                entity.Property(n => n.ProgramName);
                entity.Property(n => n.ProgramLink);
            });
            modelBuilder.Entity<ProgramSupporter>(entity =>
            {
                entity.ToTable("ProgramSupporter", "TicketContext");
                entity.Property(n => n.Id).ValueGeneratedNever();
                entity.Property(n => n.SupporterpersonID);
                entity.HasOne<Program>(n => n.Programs)
                .WithMany(n => n.Supporters)
                .HasForeignKey(n => n.Program);
            });
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable<Ticket>("Ticket", "TicketContext");
                entity.Property(n=>n.Id).ValueGeneratedNever();
                entity.Property(n=>n.PersonID);
                entity.Property(n =>n.PersonPartId);
                entity.Property(n => n.ProgramId);
                entity.Property(n => n.ErrorType);
                entity.Property(n => n.Type);
                entity.Property(n => n.ErrorDiscription);
                entity.Property(n => n.SolutionDiscription);
                entity.Property(n => n.TicketTime);
                entity.Property(n => n.TicketCondition);
                entity.Property(n => n.SupporterPersonID);








            });
            //modelBuilder.HasSequence
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
