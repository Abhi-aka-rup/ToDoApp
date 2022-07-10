using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Entities.Models;

namespace ToDoApp.Data.Contexts
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDo { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultContainer("ToDo");
            modelBuilder.Entity<ToDo>()
                .ToContainer("ToDo");
            modelBuilder.Entity<ToDo>()
                .Property(x => x.Id)
                .HasConversion<GuidToStringConverter>();
            modelBuilder.Entity<ToDo>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<ToDo>()
                .HasPartitionKey(x => x.Id);
        }
    }
}
