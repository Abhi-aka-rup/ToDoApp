using Microsoft.EntityFrameworkCore;
using ToDoApp.Data.Contexts;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Entities.Models;

namespace ToDoApp.Data.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext toDoContext)
        {
            _context = toDoContext;
        }

        public async Task<IEnumerable<ToDo>> GetAllToDoAsync()
        {
            return await _context.ToDo.ToListAsync();
        }

        public async Task<ToDo> GetToDoByIdAsync(string id)
        {
            return await _context.ToDo.Where(data => data.Id.ToString().ToLower() == id.ToLower()).FirstOrDefaultAsync();
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
