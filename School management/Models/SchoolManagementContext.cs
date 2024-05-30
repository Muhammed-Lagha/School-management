using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School_management.Models;

public partial class SchoolManagementContext : DbContext
{
    public SchoolManagementContext()
    {
    }

    public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherGrade> TeacherGrades { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SchoolManagement;Username=postgres;Password=muhammed123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("grade_pkey");

            entity.ToTable("grade");

            entity.HasIndex(e => new { e.Name, e.GradeNumber }, "grade_name_grade_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GradeNumber).HasColumnName("grade_number");
            entity.Property(e => e.Name)
                .HasMaxLength(2)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("students_pkey");

            entity.ToTable("students");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");

            entity.HasOne(d => d.Grade).WithMany(p => p.Students)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_grade_id");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subject_pkey");

            entity.ToTable("subject");

            entity.HasIndex(e => new { e.Name, e.GradeNumber }, "unique_name_grade").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.GradeNumber).HasColumnName("grade_number");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.Grade).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_grade");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teacher_pkey");

            entity.ToTable("teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.NiNo)
                .HasMaxLength(50)
                .HasColumnName("ni_no");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.ProfilePicture).HasColumnName("profile_picture");
        });

        modelBuilder.Entity<TeacherGrade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teacher_grade_pkey");

            entity.ToTable("teacher_grade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GradeId).HasColumnName("grade_id");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Grade).WithMany(p => p.TeacherGrades)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_grade_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherGrades)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_teacher_id");
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("timetable_pkey");

            entity.ToTable("timetable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DayOfWeek).HasColumnName("day_of_week");
            entity.Property(e => e.Period1SubjectId).HasColumnName("period_1_subject_id");
            entity.Property(e => e.Period2SubjectId).HasColumnName("period_2_subject_id");
            entity.Property(e => e.Period3SubjectId).HasColumnName("period_3_subject_id");
            entity.Property(e => e.Period4SubjectId).HasColumnName("period_4_subject_id");
            entity.Property(e => e.Period5SubjectId).HasColumnName("period_5_subject_id");
            entity.Property(e => e.Period6SubjectId).HasColumnName("period_6_subject_id");

            entity.HasOne(d => d.Period1Subject).WithMany(p => p.TimetablePeriod1Subjects)
                .HasForeignKey(d => d.Period1SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_period_1");

            entity.HasOne(d => d.Period2Subject).WithMany(p => p.TimetablePeriod2Subjects)
                .HasForeignKey(d => d.Period2SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_period_2");

            entity.HasOne(d => d.Period3Subject).WithMany(p => p.TimetablePeriod3Subjects)
                .HasForeignKey(d => d.Period3SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_period_3");

            entity.HasOne(d => d.Period4Subject).WithMany(p => p.TimetablePeriod4Subjects)
                .HasForeignKey(d => d.Period4SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_period_4");

            entity.HasOne(d => d.Period5Subject).WithMany(p => p.TimetablePeriod5Subjects)
                .HasForeignKey(d => d.Period5SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_period_5");

            entity.HasOne(d => d.Period6Subject).WithMany(p => p.TimetablePeriod6Subjects)
                .HasForeignKey(d => d.Period6SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_period_6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
