﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentCourseEnrollment;

namespace StudentCourseEnrollment.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentCourseEnrollment.CourseDetails", b =>
                {
                    b.Property<int>("CourseCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CourseFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CourseStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<int?>("RegisterationRegID")
                        .HasColumnType("int");

                    b.HasKey("CourseCode")
                        .HasName("PK_CourseCode");

                    b.HasIndex("RegisterationRegID");

                    b.ToTable("CoursesDetails");
                });

            modelBuilder.Entity("StudentCourseEnrollment.Registeration", b =>
                {
                    b.Property<int>("RegID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("RegID")
                        .HasName("PK_RegId");

                    b.HasIndex("CourseCode");

                    b.HasIndex("StudentId");

                    b.ToTable("Registeration");
                });

            modelBuilder.Entity("StudentCourseEnrollment.Studentdetails", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RegisterationRegID")
                        .HasColumnType("int");

                    b.Property<string>("StudAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StudDOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudEmailAdd")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("StudGender")
                        .HasColumnType("int");

                    b.Property<string>("StudName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StudphNum")
                        .HasColumnType("bigint")
                        .HasMaxLength(10);

                    b.HasKey("StudentId")
                        .HasName("PK_StudenID");

                    b.HasIndex("RegisterationRegID");

                    b.ToTable("StudentDetails");
                });

            modelBuilder.Entity("StudentCourseEnrollment.CourseDetails", b =>
                {
                    b.HasOne("StudentCourseEnrollment.Registeration", "Registeration")
                        .WithMany()
                        .HasForeignKey("RegisterationRegID");
                });

            modelBuilder.Entity("StudentCourseEnrollment.Registeration", b =>
                {
                    b.HasOne("StudentCourseEnrollment.CourseDetails", "CourseDetails")
                        .WithMany()
                        .HasForeignKey("CourseCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentCourseEnrollment.Studentdetails", "Studdetails")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentCourseEnrollment.Studentdetails", b =>
                {
                    b.HasOne("StudentCourseEnrollment.Registeration", "Registeration")
                        .WithMany()
                        .HasForeignKey("RegisterationRegID");
                });
#pragma warning restore 612, 618
        }
    }
}