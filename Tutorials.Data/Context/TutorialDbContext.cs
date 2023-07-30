using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorials.Data.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Tutorials.Data.Context
{
    public class TutorialDbContext : IdentityDbContext<User>
    {
        public TutorialDbContext(DbContextOptions<TutorialDbContext> Options):base(Options)
        {
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

    }
}
