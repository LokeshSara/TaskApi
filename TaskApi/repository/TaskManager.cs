using System;
using System.Collections.Generic;
using System.Linq;
using TaskApi.Model;

namespace TaskApi.repository
{
    public class TaskManager : ITaskManagerRepository
    {
        public void AddTask(TaskDTO tsk)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskDTO> GetAllTask()
        {

            throw new NotImplementedException();
        }

        public TaskDTO GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskDTO> SearchTask(TaskDTO tsk)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(TaskDTO tsk)
        {
            throw new NotImplementedException();
        }
    }
}
