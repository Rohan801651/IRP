using Microsoft.EntityFrameworkCore;
using Students.Models; // Reference to Student project

namespace ReceptionService.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<StudentClasses> StudentClasses { get; set; }
        public DbSet<StudentSubjects> StudentSubjects { get; set; }
        public DbSet<ClassSubject> ClassSubjects { get; set; }
        public DbSet<FieldSubject> FieldSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique index for RollNumber
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.RollNumber)
                .IsUnique();

            // Student -> StudentClasses
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(sc => sc.Students)
                .HasForeignKey(s => s.ClassID)
                .OnDelete(DeleteBehavior.Restrict);

            // Student -> Fields (nullable)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Field)
                .WithMany(f => f.Students)
                .HasForeignKey(s => s.FieldID)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Fields -> StudentClasses
            modelBuilder.Entity<Fields>()
                .HasOne(f => f.Class)
                .WithMany(sc => sc.Fields)
                .HasForeignKey(f => f.ClassID)
                .OnDelete(DeleteBehavior.Restrict);

            // ClassSubject relationships
            modelBuilder.Entity<ClassSubject>()
                .HasOne(cs => cs.Class)
                .WithMany(sc => sc.ClassSubjects)
                .HasForeignKey(cs => cs.ClassID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassSubject>()
                .HasOne(cs => cs.Subject)
                .WithMany(ss => ss.ClassSubjects)
                .HasForeignKey(cs => cs.SubjectID)
                .OnDelete(DeleteBehavior.Restrict);

            // FieldSubject relationships
            modelBuilder.Entity<FieldSubject>()
                .HasOne(fs => fs.Field)
                .WithMany(f => f.FieldSubjects)
                .HasForeignKey(fs => fs.FieldID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FieldSubject>()
                .HasOne(fs => fs.Subject)
                .WithMany(ss => ss.FieldSubjects)
                .HasForeignKey(fs => fs.SubjectID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}