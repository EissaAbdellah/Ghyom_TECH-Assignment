﻿// <auto-generated />
using System;
using GhyomAssignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GhyomAssignment.Migrations
{
    [DbContext(typeof(NWC_Context))]
    [Migration("20230723113243_reconnectDB")]
    partial class reconnectDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Default_Slice_Values", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NWC_Default_Slice_Values_Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("NWC_Default_Slice_Values_Condtion")
                        .HasColumnType("int");

                    b.Property<string>("NWC_Default_Slice_Values_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NWC_Default_Slice_Values_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("NWC_Default_Slice_Values_Sanitation_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NWC_Default_Slice_Values_Water_Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("NWC_Default_Slice_Values");
                });

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Invoices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("NWC_Invoices_Amount_Consumption")
                        .HasColumnType("int");

                    b.Property<int>("NWC_Invoices_Current_Consumption_Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("NWC_Invoices_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NWC_Invoices_From")
                        .HasColumnType("datetime2");

                    b.Property<bool>("NWC_Invoices_Is_There_Sanitation")
                        .HasColumnType("bit");

                    b.Property<string>("NWC_Invoices_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NWC_Invoices_Previous_Consumption_Amount")
                        .HasColumnType("int");

                    b.Property<int>("NWC_Invoices_Rreal_Estate_Types_No")
                        .HasColumnType("int");

                    b.Property<decimal>("NWC_Invoices_Service_Fee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NWC_Invoices_Subscriber_No")
                        .HasColumnType("int");

                    b.Property<int>("NWC_Invoices_Subscription_No")
                        .HasColumnType("int");

                    b.Property<decimal>("NWC_Invoices_Tax_Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NWC_Invoices_Tax_Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("NWC_Invoices_To")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NWC_Invoices_Total_Bill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NWC_Invoices_Total_Invoice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NWC_Invoices_Total_Reasons")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NWC_Invoices_Wastewater_Consumption_Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NWC_Invoices_Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("NWC_Invoices_Rreal_Estate_Types_No");

                    b.HasIndex("NWC_Invoices_Subscriber_No");

                    b.HasIndex("NWC_Invoices_Subscription_No");

                    b.ToTable("NWC_Invoices");
                });

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Rreal_Estate_Types", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NWC_Rreal_Estate_Types_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NWC_Rreal_Estate_Types_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NWC_Rreal_Estate_Types_Reasons")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("NWC_Rreal_Estate_Types");
                });

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Subscriber_File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NWC_Subscriber_File_Area")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NWC_Subscriber_File_City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NWC_Subscriber_File_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NWC_Subscriber_File_Mobile")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NWC_Subscriber_File_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NWC_Subscriber_File_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("NWC_Subscriber_Files");
                });

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Subscription_File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("NWC_Subscription_File_Is_There_Sanitation")
                        .HasColumnType("bit");

                    b.Property<int>("NWC_Subscription_File_Last_Reading_Meter")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("NWC_Subscription_File_Reasons")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NWC_Subscription_File_Rreal_Estate_Types_Code")
                        .HasColumnType("int");

                    b.Property<int>("NWC_Subscription_File_Subscriber_Code")
                        .HasColumnType("int");

                    b.Property<int>("NWC_Subscription_File_Unit_No")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NWC_Subscription_File_Rreal_Estate_Types_Code");

                    b.HasIndex("NWC_Subscription_File_Subscriber_Code");

                    b.ToTable("NWC_Subscription_Files");
                });

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Invoices", b =>
                {
                    b.HasOne("GhyomAssignment.Models.NWC_Rreal_Estate_Types", "NWC_Rreal_Estate_Types")
                        .WithMany("NWC_Invoices")
                        .HasForeignKey("NWC_Invoices_Rreal_Estate_Types_No")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GhyomAssignment.Models.NWC_Subscriber_File", "NWC_Subscriber_File")
                        .WithMany("NWC_Invoices")
                        .HasForeignKey("NWC_Invoices_Subscriber_No")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GhyomAssignment.Models.NWC_Subscription_File", "NWC_Subscription_File")
                        .WithMany("NWC_Invoices")
                        .HasForeignKey("NWC_Invoices_Subscription_No")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NWC_Rreal_Estate_Types");

                    b.Navigation("NWC_Subscriber_File");

                    b.Navigation("NWC_Subscription_File");
                });

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Subscription_File", b =>
                {
                    b.HasOne("GhyomAssignment.Models.NWC_Rreal_Estate_Types", "NWC_Rreal_Estate_Types")
                        .WithMany("NWC_Subscription_Files")
                        .HasForeignKey("NWC_Subscription_File_Rreal_Estate_Types_Code")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GhyomAssignment.Models.NWC_Subscriber_File", "NWC_Subscriber_File")
                        .WithMany("NWC_Subscription_Files")
                        .HasForeignKey("NWC_Subscription_File_Subscriber_Code")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NWC_Rreal_Estate_Types");

                    b.Navigation("NWC_Subscriber_File");
                });

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Rreal_Estate_Types", b =>
                {
                    b.Navigation("NWC_Invoices");

                    b.Navigation("NWC_Subscription_Files");
                });

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Subscriber_File", b =>
                {
                    b.Navigation("NWC_Invoices");

                    b.Navigation("NWC_Subscription_Files");
                });

            modelBuilder.Entity("GhyomAssignment.Models.NWC_Subscription_File", b =>
                {
                    b.Navigation("NWC_Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
