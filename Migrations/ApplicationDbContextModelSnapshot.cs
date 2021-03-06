// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPage.Models;

namespace RazorPage.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RazorPage.Models.Journal", b =>
                {
                    b.Property<int>("EntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EntryDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EntryName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("StarredEntry")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("EntryID");

                    b.ToTable("journal");
                });
#pragma warning restore 612, 618
        }
    }
}
