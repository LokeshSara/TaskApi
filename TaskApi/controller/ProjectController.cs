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
    [Route("api/project")]
    public class ProjectController : Controller
    {
        private IProjectRepository _repository;

        public ProjectController(IProjectRepository repo)
        {
            _repository = repo;
        }

        [HttpGet("")]
        public IActionResult GetAllProjects()
        {
            try
            {
                var projects = _repository.GetAllProject();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }





        }

        [HttpGet("{id}")]
        public IActionResult GetPrjectById(int id)
        {
            var project = _repository.GetProjectById(id);



            return Ok(project);
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] ProjectSearchOptions searchoption)
        {


            var projects = _repository.SerachProject(searchoption);



            return Ok(projects);
        }

        [HttpPost("add")]
        public IActionResult AddProject([FromBody] ProjectDTO ProjectDtoInfo)
        {
           

            var project = new Entity.Project
            {
                ProjectDesc = ProjectDtoInfo.ProjectDesc,
                 StartDate = ProjectDtoInfo.StartDate,
                  EndDate = ProjectDtoInfo.EndDate,
                   Priority = ProjectDtoInfo.Priority,
                   ManagerId =ProjectDtoInfo.ManagerId,
                   
            };


            _repository.AddProject(project);



            return Ok(true);
        }

        [HttpPost("update")]
        public IActionResult UpdateProject([FromBody] ProjectDTO projectDtoInfo)
        {

            var project = new Entity.Project
            {
                ProjectId = projectDtoInfo.ProjectId,
                ProjectDesc = projectDtoInfo.ProjectDesc,
                StartDate = projectDtoInfo.StartDate,
                EndDate = projectDtoInfo.EndDate,
                Priority = projectDtoInfo.Priority,
                ManagerId = projectDtoInfo.ManagerId
            };

            _repository.UpdateProject(project);



            return Ok(true);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProject(int id)
        {


            _repository.DeleteProject(id);



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
