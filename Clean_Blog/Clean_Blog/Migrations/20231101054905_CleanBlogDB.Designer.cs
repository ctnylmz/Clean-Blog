﻿// <auto-generated />
using Clean_Blog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clean_Blog.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231101054905_CleanBlogDB")]
    partial class CleanBlogDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Clean_Blog.Models.Header", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Menu1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Menu2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Menu3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Menu4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Headers");
                });
#pragma warning restore 612, 618
        }
    }
}