using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities.Models;

namespace ToDoApp.Data.Contexts
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<ToDo> ToDo { get; set; }
    }
}
