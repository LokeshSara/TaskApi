using Moq;
using NBench;
using System;
using System.Collections.Generic;
using System.Text;
using TaskApi.controller;
using TaskApi.Model;
using TaskApi.repository;

namespace TaskApi.Perf.Test
{
    public class UserPerfTest
    {
        private Counter _counter;
        private Mock<IUserRepository> _repository;
        private UserController _controller;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
            _repository = new Mock<IUserRepository>();
            _controller = new UserController(_repository.Object);

        }
        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
         TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void GetAllUsers_ShouldGetAllUsers()
        {
            var returnData = new List<UserDTO>();
            returnData.Add(new UserDTO { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 });


            _repository.Setup(service => service.GetAllUsers())
                        .Returns(returnData);

            var response = _controller.GetAllUsers();

            _counter.Increment();
        }


        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void GetUserById_ShouldGetUserByID()
        {
            var returnData = new UserDTO { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };


            _repository.Setup(service => service.GetUserById(1))
                        .Returns(returnData);

            var response = _controller.GetUserById(1);

            _counter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
          TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void Search_ShouldGetUserBySearchParam()
        {
            var returnData = new List<UserDTO>();
            returnData.Add(new UserDTO { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 });

            var searchOption = new UserSearchOption { SearchKey = "Key" };

            _repository.Setup(service => service.SerachUser(searchOption))
                        .Returns(returnData);

            var response = _controller.Search(searchOption);

            _counter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
         TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void DeleteProject_ShouldDeleteProject()
        {


            _repository.Setup(service => service.DeleteUser(1));


            var response = _controller.DeleteUser(1);

            _counter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void AddProject_ShouldAddProjectDetails()
        {

            var user = new Entity.User { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };

            var userdto = new UserDTO { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };


            _repository.Setup(service => service.AddUser(user));


            var response = _controller.AddUser(userdto);

            _counter.Increment();

        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput,
        RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void UpdateProject_ShouldUpdateProjectDetails()
        {
            var user = new Entity.User { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };

            var userdto = new UserDTO { UserId = 1, FirstName = "First Name", LastName = "Last Name", EmployeeId = 1, ProjectId = 1, TaskId = 1 };


            _repository.Setup(service => service.UpdateUser(user));


            var response = _controller.UpdateUser(userdto);

            _counter.Increment();
        }

    }
}
