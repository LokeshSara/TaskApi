using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Entity;
using TaskApi.Model;

namespace TaskApi.repository
{
    public class Project : IProjectRepository
    {
        private TaskDBContext _context;

        public Project(TaskDBContext context)
        {
            _context = context;
        }

        public void AddProject(Entity.Project proj)
        {
            _context.Add(proj);
            _context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var proj = _context.Projects.Where(a => a.ProjectId == id).FirstOrDefault();
            _context.Remove(proj);
            _context.SaveChanges();
        }

        public List<ProjectDTO> GetAllProject()
        {
            var projects = _context.Projects.ToList().Select(t => new ProjectDTO
            {
                ProjectId = t.ProjectId,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Priority = t.Priority,
                ManagerId  = t.ManagerId,
                ProjectDesc = t.ProjectDesc,
               
            });

            return projects.ToList();
        }

        public ProjectDTO GetProjectById(int id)
        {
            var project = _context.Projects.ToList().Where(t => t.ProjectId == id).
              Select(t => new ProjectDTO
              {
                  ProjectId = t.ProjectId,
                  StartDate = t.StartDate,
                  EndDate = t.EndDate,
                  Priority = t.Priority,
                  ManagerId = t.ManagerId,
                  ProjectDesc = t.ProjectDesc
              });



            return project.FirstOrDefault();
        }

        public List<ProjectDTO> SerachProject(ProjectSearchOptions optn)
        {
            var items = _context.Projects.Where(s => s.ProjectDesc.Contains(optn.SearchKey));

            var result = items.Select(t => new ProjectDTO
            {
                ProjectId = t.ProjectId,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Priority = t.Priority,
                ManagerId = t.ManagerId,
                ProjectDesc = t.ProjectDesc
            });

            return result.ToList();
        }

        public void UpdateProject(Entity.Project proj)
        {
            _context.Update(proj);
            _context.SaveChanges();
        }
    }
}
