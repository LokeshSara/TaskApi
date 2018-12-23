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
            try
            {
                var tasks = _repository.GetAllTask();
                return Ok(tasks);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        

            
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var tasks = _repository.GetTaskById(id);

         

            return Ok(tasks);
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] SearchOptions searchoption)
        {
            

            var tasks = _repository.SearchTask(searchoption);

          

            return Ok(tasks);
        }

        [HttpPost("add")]
        public IActionResult AddTask([FromBody] TaskDTO TaskDtoInfo)
        {

            var task = new Entity.Task { 
                 TaskDesc = TaskDtoInfo.TaskDesc,
                 ParentId = TaskDtoInfo.ParentId,
                 StartDate = TaskDtoInfo.StartDate,
                 EndDate = TaskDtoInfo.EndDate,
                  Priority = TaskDtoInfo.Priority,
            };

            _repository.AddTask(task);

            

            return Ok(true);
        }

        [HttpPost("update")]
        public IActionResult UpdateTask([FromBody] TaskDTO TaskDtoInfo)
        {

            var task = new Entity.Task
            {
                TaskId = TaskDtoInfo.TaskId,
                TaskDesc = TaskDtoInfo.TaskDesc,
                ParentId = TaskDtoInfo.ParentId,
                StartDate = TaskDtoInfo.StartDate,
                EndDate = TaskDtoInfo.EndDate,
                Priority = TaskDtoInfo.Priority,
            };

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
