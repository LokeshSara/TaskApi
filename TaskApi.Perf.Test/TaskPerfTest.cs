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

        //[PerfBenchmark(NumberOfIterations = 3, RunMode = RunMode.Throughput,
        //RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        //[CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        //[CounterTotalAssertion("TestCounter", MustBe.GreaterThan, 10000000.0d)]
        //[CounterMeasurement("TestCounter")]
        //public void Benchmark()
        //{
        //    _counter.Increment();
        //}

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput,
        RunTimeMilliseconds = 1000, TestMode = TestMode.Measurement)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 500.0d)]
        public void GetAllTask_BenchMark()
        {
            var returnData = new List<TaskDTO>();
            returnData.Add(new TaskDTO { TaskId = 1, TaskDesc = "First Task", StartDate = Convert.ToDateTime("12/07/2018"), EndDate = Convert.ToDateTime("12/31/2018"), Priority = 1 });


            _repository.Setup(service => service.GetAllTask())
                        .Returns(returnData);

            var response = _controller.GetAllTask();

            _counter.Increment();
        }
    }
}
