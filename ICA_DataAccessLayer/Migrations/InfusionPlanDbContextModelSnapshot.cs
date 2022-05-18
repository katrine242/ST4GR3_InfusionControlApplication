﻿// <auto-generated />
using ICA_DataAccessLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ICA_DataAccessLayer.Migrations
{
    [DbContext(typeof(InfusionPlanDbContext))]
    partial class InfusionPlanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("DTO_Library.DTO_InfusionPlan", b =>
                {
                    b.Property<int>("InfusionPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BatchId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPR")
                        .HasColumnType("TEXT");

                    b.Property<double>("Concentration")
                        .HasColumnType("REAL");

                    b.Property<double>("Factor")
                        .HasColumnType("REAL");

                    b.Property<int>("Fulltime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IntervalTime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MachineID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MaxDoseage")
                        .HasColumnType("REAL");

                    b.Property<string>("MedicineName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientName")
                        .HasColumnType("TEXT");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("InfusionPlanId");

                    b.ToTable("InfusionPlans");
                });

            modelBuilder.Entity("DTO_Library.DTO_TimeFlow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DtoInfusionPlanId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Flow")
                        .HasColumnType("REAL");

                    b.Property<double>("Time")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("DtoInfusionPlanId");

                    b.ToTable("TimeFlows");
                });

            modelBuilder.Entity("DTO_Library.DTO_TimeFlow", b =>
                {
                    b.HasOne("DTO_Library.DTO_InfusionPlan", "DtoInfusionPlan")
                        .WithMany("DtoTimeFlowList")
                        .HasForeignKey("DtoInfusionPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DtoInfusionPlan");
                });

            modelBuilder.Entity("DTO_Library.DTO_InfusionPlan", b =>
                {
                    b.Navigation("DtoTimeFlowList");
                });
#pragma warning restore 612, 618
        }
    }
}
