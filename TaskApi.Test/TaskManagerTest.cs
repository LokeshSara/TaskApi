
using Moq;
using TaskApi.repository;
using TaskApi.controller;
using System.Collections.Generic;
using TaskApi.Model;
using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using NBench;
using AutoMapper.Configuration;
using AutoMapper;
using Xunit.Sdk;
using System.Collections.Concurrent;
using System.Reflection;
using Xunit.Abstractions;
using System.Linq;

namespace TaskApi.Test
{

    
    public class TaskManagerTest 
    {
        private Mock<ITaskManagerRepository> _repository;
        private TaskController _controller;
   


        //[AssemblyInitialize]
        //public static void Init(TestContext context)
        //{
        //    // Initalization code goes here
        //}







        public TaskManagerTest()
        {
          
            _repository = new Mock<ITaskManagerRepository>();
            _controller = new TaskController(_repository.Object);

            
        }

      

        [Fact]
        public void GetAllTask_ShouldGetAllTask()
        {
            var returnData = new List<TaskDTO>();
            returnData.Add(new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 });


            _repository.Setup(service => service.GetAllTask())
                        .Returns(returnData);

            var response = _controller.GetAllTask();

            var okResult = response as OkObjectResult;
            var items = okResult.Value as List<TaskDTO>;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void PingTest_ShouldTestPing()
        {
            var returnData = "Success!!!";

            //_repository.Setup(service => service.GetAllTask())
            //            .Returns(returnData);

            var response = _controller.PingTest();

            var okResult = response as OkObjectResult;
            var items = okResult.Value as string;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(returnData, Convert.ToString(items));
        }

        [Fact]
        public void GetTaskById_ShouldGetTaskByID()
        {
            var returnData = new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };


            _repository.Setup(service => service.GetTaskById(1))
                        .Returns(returnData);

            var response = _controller.GetTaskById(1);

            var okResult = response as OkObjectResult;
            var items = okResult.Value as TaskDTO;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal("First Task", items.TaskDesc);
        }

        [Fact]
        public void Search_ShouldGetTaskBySearchParam()
        {
            var returnData = new List<TaskDTO>();
            returnData.Add(new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 });

            var searchOption = new SearchOptions { TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018") };

            _repository.Setup(service => service.SearchTask(searchOption))
                        .Returns(returnData);

            var response = _controller.Search(searchOption);

            var okResult = response as OkObjectResult;
            var items = okResult.Value as List<TaskDTO>;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void DeleteTask_ShouldDeleteTask()
        {
            //var returnData = new List<TaskDTO>();
            //returnData.Add(new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = null, Priority = 1 });


            _repository.Setup(service => service.DeleteTask(1));
                        

            var response = _controller.DeleteTask(1);

            var okResult = response as OkObjectResult;


            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void AddTask_ShouldAddTaskDetails()
        {


            var task = new Entity.Task { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = 1, Priority = 1 };

            var taskDto = new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = 0, Priority = 1 };

            _repository.Setup(service => service.AddTask(task));
                        

            var response = _controller.AddTask(taskDto);

            var okResult = response as OkObjectResult;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void UpdateTask_ShouldUpdateTaskDetails()
        {
            var task = new Entity.Task { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = 1, Priority = 1 };

            var taskDto = new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = 0, Priority = 1 };

            _repository.Setup(service => service.UpdateTask(task));


            var response = _controller.UpdateTask(taskDto);

            var okResult = response as OkObjectResult;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }
    }

}
