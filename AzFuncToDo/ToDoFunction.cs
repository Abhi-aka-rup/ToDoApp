using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using ToDoApp.Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ToDoApp.Entities.Models;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Entities.ViewModels;
using System;

namespace AzFuncToDo
{
    public class ToDoFunction
    {
        private readonly IToDoRepository _toDoRepository;
        //private readonly IMapper _mapper;

        public ToDoFunction(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
            //_mapper = mapper;
        }

        private bool isListEmptyOrNull(IEnumerable<ToDo> toDoViewModelList)
        {
            if (toDoViewModelList == null || toDoViewModelList.Count() == 0)
            {
                return true;
            }
            return false;
        }

        [FunctionName("GetAll")]
        public async Task<IActionResult> GetAllToDo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
            ILogger logger)
        {
            logger.LogInformation("Trying to get all to-do items");

            try
            {
                var toDoList = await _toDoRepository.GetAllToDoAsync();
                if (isListEmptyOrNull(toDoList))
                {
                    return new NotFoundObjectResult("No data exist");
                }
                //return new OkObjectResult(_mapper.Map<IEnumerable<ToDoViewModel>>(toDoList));
                return new OkObjectResult(toDoList);
            }
            catch (Exception ex)
            {
                var response = new ObjectResult(ex.Message);
                response.StatusCode = 500;
                return response;
            }

        }
    }
}
