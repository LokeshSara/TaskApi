using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Model;

namespace TaskApi.repository
{
    public interface IProjectRepository
    {
        List<ProjectDTO> GetAllProject();

        ProjectDTO GetProjectById(int id);

        List<ProjectDTO> SerachProject(ProjectSearchOptions optn);

        void UpdateProject(Entity.Project usr);

        void DeleteProject(int id);

        void AddProject(Entity.Project tsk);
    }
}
