using Moq;
using NBench;
using System;
using System.Collections.Generic;
using TaskApi.controller;
using TaskApi.Model;
using TaskApi.repository;

namespace TaskApi.Perf.Test
{
    public class TaskPerfTest
    {
        private Counter _counter;
        private Mock<ITaskManagerRepository> _repository;
        private TaskController _controller;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
            _repository = new Mock<ITaskManagerRepository>();
            _controller = new TaskController(_repository.Object);

        }
        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }


        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void GetAllTask_BenchMark()
        {
            var returnData = new List<TaskDTO>();
            returnData.Add(new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 });


            _repository.Setup(service => service.GetAllTask())
                        .Returns(returnData);

            var response = _controller.GetAllTask();

            _counter.Increment();
        }




        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void GetTaskById_ShouldGetTaskByID()
        {
            var returnData = new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };


            _repository.Setup(service => service.GetTaskById(1))
                        .Returns(returnData);

            var response = _controller.GetTaskById(1);

            _counter.Increment();
        }


        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void Search_ShouldGetTaskBySearchParam()
        {
            var returnData = new List<TaskDTO>();
            returnData.Add(new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 });

            var searchOption = new SearchOptions { TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018") };

            _repository.Setup(service => service.SearchTask(searchOption))
                        .Returns(returnData);

            var response = _controller.Search(searchOption);

            _counter.Increment();
        }


        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void DeleteTask_ShouldDeleteTask()
        {
            //var returnData = new List<TaskDTO>();
            //returnData.Add(new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = null, Priority = 1 });


            _repository.Setup(service => service.DeleteTask(1));


            var response = _controller.DeleteTask(1);
            _counter.Increment();
        }


        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void AddTask_ShouldAddTaskDetails()
        {


            var task = new Entity.Task { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = 1, Priority = 1 };

            var taskDto = new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = 0, Priority = 1 };

            _repository.Setup(service => service.AddTask(task));


            var response = _controller.AddTask(taskDto);

            _counter.Increment();

        }


        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void UpdateTask_ShouldUpdateTaskDetails()
        {
            var task = new Entity.Task { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = 1, Priority = 1 };

            var taskDto = new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), ParentId = 0, Priority = 1 };

            _repository.Setup(service => service.UpdateTask(task));


            var response = _controller.UpdateTask(taskDto);

            _counter.Increment();
        }

    }
}
