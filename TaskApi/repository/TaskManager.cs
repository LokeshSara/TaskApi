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

        public void AddTask(Entity.Task tsk)
        {
            _context.Add(tsk);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Where(a => a.TaskId == id).FirstOrDefault();
            _context.Remove(task);
            _context.SaveChanges();
        }

        public List<Entity.Task> GetAllTask()
        {
            
                         
            return _context.Tasks.ToList();
      
        }

        public Entity.Task GetTaskById(int id)
        {
            var items = from task in _context.Tasks
                        where task.TaskId == id
                        select new Entity.Task
                        {
                            TaskId = task.TaskId,
                            TaskDesc = task.TaskDesc,
                            StartDate = task.StartDate,
                            EndDate = task.EndDate,
                            ParentId = task.ParentId,
                            Priority = task.Priority
                        };

            return items.FirstOrDefault();
        }

        public List<Entity.Task> SearchTask(TaskDTO tsk)
        {   
            var items = from task in _context.Tasks
                        where task.TaskDesc.Contains(tsk.TaskDesc)||
                                (task.Priority >= tsk.PriorityMin && task.Priority <= tsk.PriorityMax) || task.StartDate == tsk.StartDate || task.EndDate ==tsk.EndDate
                        select new Entity.Task
                        {
                            TaskId = task.TaskId,
                            TaskDesc = task.TaskDesc,
                            StartDate = task.StartDate,
                            EndDate = task.EndDate,
                            ParentId = task.ParentId,
                            Priority = task.Priority
                        };

            return items.ToList();
        }

        public void UpdateTask(Entity.Task tsk)
        {
            _context.Update(tsk);
            _context.SaveChanges();
        }
    }
}
