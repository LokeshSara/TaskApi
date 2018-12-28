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
    public class ProjectPerfTest
    {
        private Counter _counter;
        private Mock<IProjectRepository> _repository;
        private ProjectController _controller;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
            _repository = new Mock<IProjectRepository>();
            _controller = new ProjectController(_repository.Object);

        }
        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void GetAllProject_ShouldGetAllProject()
        {
            var returnData = new List<ProjectDTO>();
            returnData.Add(new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 });


            _repository.Setup(service => service.GetAllProject())
                        .Returns(returnData);

            var response = _controller.GetAllProjects();

            _counter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void GetProjectById_ShouldGetProjectByID()
        {
            var returnData = new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };


            _repository.Setup(service => service.GetProjectById(1))
                        .Returns(returnData);

            var response = _controller.GetPrjectById(1);

            _counter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void Search_ShouldGetProjectBySearchParam()
        {
            var returnData = new List<ProjectDTO>();
            returnData.Add(new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 });

            var searchOption = new ProjectSearchOptions { SearchKey = "Key" };

            _repository.Setup(service => service.SerachProject(searchOption))
                        .Returns(returnData);

            var response = _controller.Search(searchOption);

            _counter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
         TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void DeleteProject_ShouldDeleteProject()
        {


            _repository.Setup(service => service.DeleteProject(1));


            var response = _controller.DeleteProject(1);

            _counter.Increment();
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
         TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void AddProject_ShouldAddProjectDetails()
        {




            var project = new Entity.Project { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };

            var projectdto = new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };

            _repository.Setup(service => service.AddProject(project));


            var response = _controller.AddProject(projectdto);
            _counter.Increment();

        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Iterations,
        TestMode = TestMode.Test)]
        [CounterMeasurement("TestCounter")]
        public void UpdateProject_ShouldUpdateProjectDetails()
        {
            var projecct = new Entity.Project { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };

            var projectdto = new ProjectDTO { ProjectId = 1, ProjectDesc = "Project 1", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 };

            _repository.Setup(service => service.UpdateProject(projecct));


            var response = _controller.UpdateProject(projectdto);

            _counter.Increment();
        }


    }
}
