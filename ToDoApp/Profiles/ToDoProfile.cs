using AutoMapper;
using ToDoApp.Entities.Models;
using ToDoApp.Entities.ViewModels;

namespace ToDoApp.Profiles
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDo, ToDoViewModel>()
                .ReverseMap();
        }
    }
}
