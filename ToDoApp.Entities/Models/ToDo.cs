using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Entities.Models
{
    public class ToDo
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
