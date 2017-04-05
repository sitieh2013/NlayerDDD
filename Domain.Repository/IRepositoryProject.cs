using Domain.Core.Paged;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IRepositoryProject
    {
        IEnumerable<Project> GetListAll();

        IPage<Project> GetProjectPages(IPageable paged);

        Project GetProject(string code);

        void CreateProject(Project projectNew);

        void UpdateProject(Project project);
    }
}
