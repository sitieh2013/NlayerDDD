using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IRepositoryProject
    {
        IEnumerable<Project> GetListAll();

        Project GetProject(string code);

        void CreateProject(Project projectNew);

        void UpdateProject(Project project);
    }
}
