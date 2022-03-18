using DiaryMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DiaryMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<UniversitySubject> UniversitySubjects { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Task>().Property(x => x.UserDeadline).IsRequired(false);
            builder.Entity<Task>().Property(x => x.Name).IsRequired();
            builder.Entity<Task>().Property(x => x.TaskEndDate).IsRequired(false);
        }
    }
}
