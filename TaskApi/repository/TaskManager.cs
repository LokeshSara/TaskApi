using System;
using System.Collections.Generic;
using TaskApi.Entity;
using TaskApi.Model;
using System.Linq;
using AutoMapper;

namespace TaskApi.repository
{
    public class TaskManager : ITaskManagerRepository
    {
        private TaskDBContext _context;

        public TaskManager(TaskDBContext context)
        {
            _context = context;
        }

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
            var items = from task in _context.Tasks
                        join parent in _context.ParentTask on task.ParentId equals parent.ParentId
                        select new TaskDTO
                        {
                            TaskId = task.TaskId,
                            TaskDesc = task.TaskDesc,
                            StartDate = task.StartDate,
                            EndDate  = task.EndDate,
                            ParentId= task.ParentId,
                            ParentDesc = parent.ParentTaskDesc,
                            Priority = task.Priority
                        };
                         
            return items.ToList();
      
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
