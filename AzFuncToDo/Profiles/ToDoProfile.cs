using AutoMapper;
using ToDoApp.Entities.Models;
using ToDoApp.Entities.ViewModels;

namespace AzFuncToDo.Profiles
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
