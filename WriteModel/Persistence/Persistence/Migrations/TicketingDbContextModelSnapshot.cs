﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(TicketingDbContext))]
    partial class TicketingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TicketContext.Domain.Centers.Center", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("UniqueIdentifier");

                    b.Property<int>("CenterID")
                        .HasColumnType("Int");

                    b.Property<string>("CenterName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Center", "TicketContext");
                });

            modelBuilder.Entity("TicketContext.Domain.Centers.Center", b =>
                {
                    b.OwnsMany("TicketContext.Domain.Centers.Part", "Parts", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("UniqueIdentifier");

                            b1.Property<Guid>("Center")
                                .HasColumnType("UniqueIdentifier");

                            b1.Property<int>("PartID")
                                .HasColumnType("Int");

                            b1.Property<string>("PartName")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id");

                            b1.HasIndex("Center");

                            b1.ToTable("Part", "TicketContext");

                            b1.WithOwner()
                                .HasForeignKey("Center");
                        });

                    b.Navigation("Parts");
                });
#pragma warning restore 612, 618
        }
    }
}
