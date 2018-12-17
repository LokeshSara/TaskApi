using System;
using System.Collections.Generic;
using TaskApi.Entity;
using TaskApi.Model;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

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

        public List<TaskDTO> GetAllTask()
        {

            var tasks = _context.Tasks.ToList().Select(t => new TaskDTO
            {
                TaskId = t.TaskId,
                TaskDesc = t.TaskDesc,
                Priority = t.Priority,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                ParentId = t.ParentId,
                ParentDesc = GetParentDescription(t.ParentId)
            });



            return tasks.ToList();


        }

        private string GetParentDescription(int parentId)
        {
            var tsk = _context.Tasks.Where(t => t.TaskId == parentId).FirstOrDefault();
            if (tsk != null)
                return tsk.TaskDesc;
            else
                return string.Empty;
        }

        public TaskDTO GetTaskById(int id)
        {
          

            var tasks = _context.Tasks.ToList().Where(t=>t.TaskId==id).
                Select(t => new TaskDTO
                {
                    TaskId = t.TaskId,
                    TaskDesc = t.TaskDesc,
                    Priority = t.Priority,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    ParentId = t.ParentId,
                    ParentDesc = GetParentDescription(t.ParentId)
                });



            return tasks.FirstOrDefault();
        }

        public List<TaskDTO> SearchTask(SearchOptions optn)
        {
            //var items = from task in _context.Tasks
            //            where task.TaskDesc.Contains(optn.TaskDesc)||
            //                    (task.Priority >= optn.PriorityMin && task.Priority <= optn.PriorityMax) || task.StartDate == optn.StartDate || task.EndDate == optn.EndDate
            //            select new TaskDTO
            //            {
            //                TaskId = task.TaskId,
            //                TaskDesc = task.TaskDesc,
            //                StartDate = task.StartDate,
            //                EndDate = task.EndDate,
            //                ParentId = task.ParentId,
            //                Priority = task.Priority,
            //                ParentDesc = GetParentDescription(task.ParentId)
            //            };

            var items = _context.Tasks.ToList();

            if (optn.PriorityMin > 0 && optn.PriorityMax > 0)
                items = items.Where(task => task.Priority >= optn.PriorityMin && task.Priority <= optn.PriorityMax).ToList();

            if (optn.StartDate != null)
                items = items.Where(task => task.StartDate >= optn.StartDate).ToList();

            if (optn.EndDate != null)
                items = items.Where(task => task.EndDate <= optn.EndDate).ToList();

            if(optn.TaskDesc != null)
                items = items.Where(task => task.TaskDesc.Contains(optn.TaskDesc)).ToList();

            if (optn.ParentDesc != null)
                items = items.Where(task => GetParentDescription(task.ParentId).Contains(optn.ParentDesc)).ToList();
               
            var result = items.Select(t => new TaskDTO    
                {
                    TaskId = t.TaskId,
                    TaskDesc = t.TaskDesc,
                    Priority = t.Priority,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    ParentId = t.ParentId,
                    ParentDesc = GetParentDescription(t.ParentId)
                });


            return result.ToList();
        }

        public void UpdateTask(Entity.Task tsk)
        {
            _context.Update(tsk);
            _context.SaveChanges();
        }
    }
}
