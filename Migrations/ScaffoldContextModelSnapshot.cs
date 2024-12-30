﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scaffold.Entities;

#nullable disable

namespace Scaffold.Migrations
{
    [DbContext(typeof(ScaffoldContext))]
    partial class ScaffoldContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Scaffold.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlayerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<int?>("NumberOfGoals")
                        .HasColumnType("int");

                    b.Property<string>("PlayerName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(15, 2)");

                    b.Property<int?>("ShirtNumber")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int")
                        .HasColumnName("TeamID");

                    b.HasKey("PlayerId")
                        .HasName("PK__Players__4A4E74A8B59801F2");

                    b.HasIndex("TeamId");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("Scaffold.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TeamID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<decimal?>("Budget")
                        .HasColumnType("decimal(15, 2)");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("Eyear")
                        .HasColumnType("int")
                        .HasColumnName("EYear");

                    b.Property<string>("League")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("StadiumName")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("TeamName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("TeamId")
                        .HasName("PK__Teams__123AE7B910C8BF0E");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("Scaffold.Entities.Player", b =>
                {
                    b.HasOne("Scaffold.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .HasConstraintName("FK__Players__TeamID__398D8EEE");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Scaffold.Entities.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
