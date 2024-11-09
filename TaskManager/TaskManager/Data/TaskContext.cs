using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Model;

namespace TaskManager.Data
{
    public class TaskContext : DbContext

    {
        public TaskContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


                modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
               .WithOne(a => a.user)
               .HasForeignKey<Address>(a=> a.userid);

                 modelBuilder.Entity<User>()
                .HasMany(t => t.Items)
                .WithOne(u => u.assignee)
                .HasForeignKey(t => t.assigneeId);
                base.OnModelCreating(modelBuilder);
   

        }
    }

}
