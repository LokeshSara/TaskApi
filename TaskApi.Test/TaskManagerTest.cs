using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TaskApi.repository;
using TaskApi.controller;
using System.Collections.Generic;
using TaskApi.Model;
using System;
using Microsoft.AspNetCore.Mvc;

namespace TaskApi.Test
{
    [TestClass]
    public class TaskManagerTest
    {
        private Mock<ITaskManagerRepository> _repository;
        private TaskController _controller;

        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            // Initalization code goes here
        }

        public TaskManagerTest()
        {
            _repository = new Mock<ITaskManagerRepository>();
            _controller = new TaskController(_repository.Object);
        }

        [TestMethod]
        public void GetAllTask_ShouldGetAllTask()
        {
            var returnData = new List<TaskDTO>();
            returnData.Add(new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = null, Priority = 1 });


            _repository.Setup(service => service.GetAllTask())
                        .Returns(returnData);

            var response = _controller.GetAllTask();

            var okResult = response as OkObjectResult;
            var items = okResult.Value as List<TaskDTO>;

            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(1, items.Count);
        }
    }
}
