using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentUpload> StudentUploads { get; set; }
        public DbSet<StudentFile> StudentFiles { get; set; }
        public DbSet<TeacherFile> TeacherFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.TeacherId);

            modelBuilder.Entity<StudentUpload>()
                .HasKey(su => su.Id);

            modelBuilder.Entity<StudentUpload>()
                .HasOne(su => su.Student)
                .WithMany(s => s.Uploads)
                .HasForeignKey(su => su.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentUpload>()
                .Property(su => su.Uploads)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null));
        }
    }
}
