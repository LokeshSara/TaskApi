using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Model;
using TaskApi.repository;

namespace TaskApi.controller
{
    [Route("api/task")]
    public class TaskController : Controller
    {
        private ITaskManagerRepository _repository;

        public TaskController(ITaskManagerRepository repo)
        {
            _repository = repo;
        }

        [HttpGet("")]
        public IActionResult GetAllTask()
        {
            var tasks =  _repository.GetAllTask();

            //var result = Mapper.Map<IEnumerable<TaskDTO>>(tasks);

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var tasks = _repository.GetTaskById(id);

            //var result = Mapper.Map<TaskDTO>(tasks);

            return Ok(tasks);
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] SearchOptions searchoption)
        {
            

            var tasks = _repository.SearchTask(searchoption);

            //var result = Mapper.Map<IEnumerable<TaskDTO>>(tasks);

            return Ok(tasks);
        }

        [HttpPost("add")]
        public IActionResult AddTask([FromBody] TaskDTO TaskDtoInfo)
        {
            var task = Mapper.Map<Entity.Task>(TaskDtoInfo);

            _repository.AddTask(task);

            

            return Ok(true);
        }

        [HttpPost("update")]
        public IActionResult UpdateTask([FromBody] TaskDTO TaskDtoInfo)
        {

            var task = Mapper.Map<Entity.Task>(TaskDtoInfo);

            _repository.UpdateTask(task);

            

            return Ok(true);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTask(int id)
        {


            _repository.DeleteTask(id);

            

            return Ok(true);
        }





        [HttpGet("Ping")]
        public IActionResult PingTest()
        {
            var tasks = "Success!!!";
            return Ok(tasks);
        }
    }
}
