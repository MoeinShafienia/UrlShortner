﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using src;

namespace src.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200208134435_initializeDb")]
    partial class initializeDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("src.Models.Url", b =>
                {
                    b.Property<string>("ShortUrl")
                        .HasColumnType("text");

                    b.Property<string>("LongUrl")
                        .HasColumnType("text");

                    b.HasKey("ShortUrl");

                    b.ToTable("urls");
                });
#pragma warning restore 612, 618
        }
    }
}
