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

    public class UserTest 
    {

        private Mock<IUserRepository> _repository;
        private UserController _controller;
       

        public UserTest()
        {
            _repository = new Mock<IUserRepository>();
            _controller = new UserController(_repository.Object);
        }

        
        [Fact]
        public void GetAllUsers_ShouldGetAllUsers()
        {
            var returnData = new List<UserDTO>();
            returnData.Add(new UserDTO { UserId = 1, FirstName = "First Name", LastName="Last Name", EmployeeId = 1, ProjectId= 1, TaskId=1});


            _repository.Setup(service => service.GetAllUsers())
                        .Returns(returnData);

            var response = _controller.GetAllUsers();

            var okResult = response as OkObjectResult;
            var items = okResult.Value as List<UserDTO>;

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
        public void GetUserById_ShouldGetUserByID()
        {
            var returnData = new UserDTO { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };


            _repository.Setup(service => service.GetUserById(1))
                        .Returns(returnData);

            var response = _controller.GetUserById(1);

            var okResult = response as OkObjectResult;
            var items = okResult.Value as UserDTO;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal("First Name", items.FirstName);
        }

        [Fact]
        public void Search_ShouldGetUserBySearchParam()
        {
            var returnData = new List<UserDTO>();
            returnData.Add(new UserDTO { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 });

            var searchOption = new UserSearchOption { SearchKey = "Key" };

            _repository.Setup(service => service.SerachUser(searchOption))
                        .Returns(returnData);

            var response = _controller.Search(searchOption);

            var okResult = response as OkObjectResult;
            var items = okResult.Value as List<UserDTO>;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void DeleteProject_ShouldDeleteProject()
        {


            _repository.Setup(service => service.DeleteUser(1));


            var response = _controller.DeleteUser(1);

            var okResult = response as OkObjectResult;


            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void AddProject_ShouldAddProjectDetails()
        {
          
            var user = new Entity.User { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };

            var userdto = new UserDTO { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };

      
            _repository.Setup(service => service.AddUser(user));


            var response = _controller.AddUser(userdto);

            var okResult = response as OkObjectResult;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public void UpdateProject_ShouldUpdateProjectDetails()
        {
            var user = new Entity.User { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };

            var userdto = new UserDTO { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };

          
            _repository.Setup(service => service.UpdateUser(user));


            var response = _controller.UpdateUser(userdto);

            var okResult = response as OkObjectResult;

            Assert.NotNull(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
        }


    }
}
