using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet()]
        public IActionResult GetAllTask()
        {
            var tasks =  _repository.GetAllTask();
            return Ok(tasks);
        }

        [HttpGet("Ping")]
        public IActionResult PingTest()
        {
            var tasks = "Success!!!";
            return Ok(tasks);
        }
    }
}
