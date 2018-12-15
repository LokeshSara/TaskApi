using System;
using System.Collections.Generic;
using System.Linq;
using TaskApi.Model;

namespace TaskApi.repository
{
    public interface ITaskManagerRepository
    {
        List<Entity.Task> GetAllTask();

        Entity.Task GetTaskById(int id);

        List<Entity.Task> SearchTask(TaskDTO tsk);

        void UpdateTask(Entity.Task tsk);

        void DeleteTask(int id);

        void AddTask(Entity.Task tsk);
    }
}
