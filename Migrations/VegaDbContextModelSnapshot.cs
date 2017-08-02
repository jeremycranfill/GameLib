using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Vega.Data;

namespace Vega.Migrations
{
    [DbContext(typeof(VegaDbContext))]
    partial class VegaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vega.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FamilyId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Vega.Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Vega.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Designer")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Family");

                    b.Property<int>("FamilyID");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("Recommended");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Vega.Models.GameMechanic", b =>
                {
                    b.Property<int>("GameId");

                    b.Property<int>("MechanicId");

                    b.HasKey("GameId", "MechanicId");

                    b.HasIndex("MechanicId");

                    b.ToTable("GameMechanic");
                });

            modelBuilder.Entity("Vega.Models.Mechanic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("Vega.Models.Category", b =>
                {
                    b.HasOne("Vega.Models.Family", "Family")
                        .WithMany("Categories")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vega.Models.GameMechanic", b =>
                {
                    b.HasOne("Vega.Models.Game", "Game")
                        .WithMany("Mechanics")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vega.Models.Mechanic", "Mechanic")
                        .WithMany()
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
