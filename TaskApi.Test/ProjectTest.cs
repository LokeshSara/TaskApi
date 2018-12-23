using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TaskApi.controller;
using TaskApi.Model;
using TaskApi.repository;
using Xunit;

namespace TaskApi.Test
{
    

 
    public class ProjectTest 
    {
        private Mock<IProjectRepository> _repository;
        private ProjectController _controller;
     

        public ProjectTest()
        {
        
            _repository = new Mock<IProjectRepository>();
            _controller = new ProjectController(_repository.Object);


        }


        [Fact]
        public void GetAllProject_ShouldGetAllProject()
        {
            var returnData = new List<ProjectDTO>();
            returnData.Add(new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 });


            _repository.Setup(service => service.GetAllProject())
                        .Returns(returnData);

            var response = _controller.GetAllProjects();

            var okResult = response as OkObjectResult;
            var items = okResult.Value as List<ProjectDTO>;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void PingTest_ShouldTestPing()
        {
            var returnData = "Success!!!";


            var response = _controller.PingTest();

            var okResult = response as OkObjectResult;
            var items = okResult.Value as string;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(returnData, Convert.ToString(items));
        }

        [Fact]
        public void GetProjectById_ShouldGetProjectByID()
        {
            var returnData = new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };


            _repository.Setup(service => service.GetProjectById(1))
                        .Returns(returnData);

            var response = _controller.GetPrjectById(1);

            var okResult = response as OkObjectResult;
            var items = okResult.Value as ProjectDTO;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal("Project 1", items.ProjectDesc);
        }

        [Fact]
        public void Search_ShouldGetProjectBySearchParam()
        {
            var returnData = new List<ProjectDTO>();
            returnData.Add(new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 });

            var searchOption = new ProjectSearchOptions { SearchKey="Key"};

            _repository.Setup(service => service.SerachProject(searchOption))
                        .Returns(returnData);

            var response = _controller.Search(searchOption);

            var okResult = response as OkObjectResult;
            var items = okResult.Value as List<ProjectDTO>;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void DeleteProject_ShouldDeleteProject()
        {


            _repository.Setup(service => service.DeleteProject(1));


            var response = _controller.DeleteProject(1);

            var okResult = response as OkObjectResult;


            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void AddProject_ShouldAddProjectDetails()
        {

            


            var project = new Entity.Project { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };

            var projectdto = new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };

            _repository.Setup(service => service.AddProject(project));


            var response = _controller.AddProject(projectdto);

            var okResult = response as OkObjectResult;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void UpdateProject_ShouldUpdateProjectDetails()
        {
            var projecct = new Entity.Project { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };

            var projectdto = new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };

            _repository.Setup(service => service.UpdateProject(projecct));


            var response = _controller.UpdateProject(projectdto);

            var okResult = response as OkObjectResult;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }


    }
}
