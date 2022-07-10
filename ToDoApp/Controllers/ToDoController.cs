using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Entities.Models;
using ToDoApp.Entities.ViewModels;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public ToDoController(IToDoRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        private bool isListEmptyOrNull(IEnumerable<ToDo> toDoViewModelList)
        {
            if (toDoViewModelList == null || toDoViewModelList.Count() == 0)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllToDo()
        {
            try
            {
                var toDoList = await _toDoRepository.GetAllToDoAsync();
                if (isListEmptyOrNull(toDoList))
                {
                    return NotFound("No data exist");
                }
                return Ok(_mapper.Map<IEnumerable<ToDoViewModel>>(toDoList));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoById(string id)
        {
            try
            {
                var result = await _toDoRepository.GetToDoByIdAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<IEnumerable<ToDoViewModel>>(result));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToDo([FromBody] ToDoViewModel toDoViewModel)
        {
            try
            {
                var toDo = _mapper.Map<ToDo>(toDoViewModel);
                _toDoRepository.Add(toDo);
                if (await _toDoRepository.SaveChangesAsync())
                {
                    return StatusCode(201, _mapper.Map<ToDoViewModel>(toDo));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return BadRequest(ModelState);
        }
    }
}
