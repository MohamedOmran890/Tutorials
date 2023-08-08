using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorials.Data.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace Tutorials.Data.Context
{
    public class TutorialDbContext : IdentityDbContext<User>
    {
        public TutorialDbContext(DbContextOptions<TutorialDbContext> Options) : base(Options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<RoomStudent>().HasKey(k => new { k.RoomId, k.StudentId });

            builder.Entity<RoomStudent>()
                .HasOne(e => e.Room)
                .WithMany(s => s.RoomStudents)
                .HasForeignKey(e => e.RoomId);

            builder.Entity<RoomStudent>()
                .HasOne(e => e.Student)
                .WithMany(c => c.RoomStudents)
                .HasForeignKey(e => e.StudentId);

            builder.Entity<SubjectTeacher>().HasKey(k => new { k.TeacherId, k.SubjectId, k.LevelId, k.CenterId });

            builder.Entity<SubjectTeacher>()
                .HasOne(e => e.Subject)
                .WithMany(s => s.SubjectTeachers)
                .HasForeignKey(e => e.SubjectId);

            builder.Entity<SubjectTeacher>()
                .HasOne(e => e.Teacher)
                .WithMany(c => c.SubjectTeachers)
                .HasForeignKey(e => e.TeacherId);

            builder.Entity<SubjectTeacher>()
                .HasOne(e => e.Level)
                .WithMany(c => c.SubjectTeachers)
                .HasForeignKey(e => e.LevelId);

            builder.Entity<SubjectTeacher>()
            .HasOne(e => e.center)
            .WithMany(c => c.SubjectTeachers)
            .HasForeignKey(e => e.CenterId);

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<RoomStudent> RoomStudents { get; set; }
        public DbSet<SubjectTeacher> Teacher_Subjects { get; set; }


    }
}
