using ToDoApp.Entities.Models;

namespace ToDoApp.Data.Repositories.Interfaces
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetAllToDoAsync();
        Task<ToDo> GetToDoByIdAsync(int id);

        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

    }
}
