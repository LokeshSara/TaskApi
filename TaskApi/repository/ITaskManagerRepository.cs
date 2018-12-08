using System;
using System.Collections.Generic;
using System.Linq;
using TaskApi.Model;

namespace TaskApi.repository
{
    public interface ITaskManagerRepository
    {
        List<TaskDTO> GetAllTask();

        TaskDTO GetTaskById(int id);

        List<TaskDTO> SearchTask(TaskDTO tsk);

        void UpdateTask(TaskDTO tsk);

        void DeleteTask(int id);

        void AddTask(TaskDTO tsk);
    }
}
