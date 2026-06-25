using System;
using System.Collections.Generic;
using Lab2_Programming.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2_Programming.Data;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {

    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    {

    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.AverageGrade).HasColumnName("avarage_grade");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.ParentsPhone)
                .HasMaxLength(13)
                .HasColumnName("parents_phone");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.ThirdName)
                .HasMaxLength(30)
                .HasColumnName("third_name");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Students)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_teacher_id_fkey");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("teacher_pkey");

            entity.ToTable("teacher");

            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .HasColumnName("phone_number");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.TeacherClass)
                .HasMaxLength(5)
                .HasColumnName("teacher_class");
            entity.Property(e => e.ThirdName)
                .HasMaxLength(30)
                .HasColumnName("third_name");
        });

        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<Teacher>().HasData(
            new Teacher 
            { 
                TeacherId = 1, 
                Name = "Олена", 
                LastName = "Шевченко", 
                ThirdName = "Іванівна", 
                TeacherClass = "10-А", 
                PhoneNumber = "0991234567", 
                Salary = 15000 
            },
            new Teacher 
            { 
                TeacherId = 2, 
                Name = "Ігор", 
                LastName = "Коваленко", 
                ThirdName = "Петрович", 
                TeacherClass = "11-Б", 
                PhoneNumber = "0987654321", 
                Salary = 16000 
            },
            new Teacher 
            { 
                TeacherId = 3, 
                Name = "Василь", 
                LastName = "Чайка", 
                ThirdName = "Олегович", 
                TeacherClass = "9-Б", 
                PhoneNumber = "0995314367", 
                Salary = 15000 
            }
        );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
