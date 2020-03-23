using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCourseEnrollment
{
   public class SchoolDbContext : DbContext
    { 
      
        public DbSet<Studentdetails> StudentDetails { get; set; }
        public DbSet<CourseDetails> CourseDetails { get; set; }
        public DbSet<Registeration> Registeration { get; set; }

        public SchoolDbContext()
        { 

        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> Options)
        { 

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolDbFeb28;" +
                "Integrated Security=True;Connect Timeout = 30;");   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studentdetails>(entity =>
            {
                entity.ToTable("StudentDetails");
                entity
                      .HasKey(e => e.StudentId)
                      .HasName("PK_StudenID");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StudEmailAdd)
                     .IsRequired()
                     .HasMaxLength(50);

                entity.Property(e => e.StudGender)
                    .IsRequired();

                entity.Property(e => e.StudName)
                    .IsRequired();

                entity.Property(e => e.StudphNum)
                    .HasMaxLength(10);

            });
                           

            modelBuilder.Entity<CourseDetails>(entity =>
            {
                entity.ToTable("CoursesDetails");

                entity
                    .HasKey (e => e.CourseCode)
                    .HasName("PK_CourseCode");

                entity.Property(e => e.CourseCode)
                   .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);
                entity
                    .Property(e => e.Grade)
                       .HasMaxLength(1);

                entity.Property(e => e.CourseStartDate)
                    .IsRequired();

                entity.Property(e => e.CourseFee)
                     .IsRequired();
            });

            modelBuilder.Entity<Registeration>(entity =>
            {
                entity.ToTable("Registeration");

                entity.HasKey(e => e.RegID)
                      .HasName("PK_RegId");                

                entity.HasOne(e => e.Studdetails)
                   .WithMany()
                   .HasForeignKey(e => e.StudentId);                

                entity.HasOne(e => e.CourseDetails)
                   .WithMany()
                   .HasForeignKey(e => e.CourseCode);                             
            });

        }
    }
}
