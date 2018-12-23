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

        public void AddProject(Entity.Project tsk)
        {
            throw new NotImplementedException();
        }

        public void DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProjectDTO> GetAllProject()
        {
            throw new NotImplementedException();
        }

        public ProjectDTO GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProjectDTO> SerachProject(ProjectSearchOptions optn)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(Entity.Project usr)
        {
            throw new NotImplementedException();
        }
    }
}
