﻿// <auto-generated />
using ISM_Y1_Marin_Ioana_Web_Cloud_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220523124714_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ISM_Y1_Marin_Ioana_Web_Cloud_Project.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<int>("EmployeeAge")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EmployeeWage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EmployeeId");

                    b.ToTable("employees");
                });
#pragma warning restore 612, 618
        }
    }
}