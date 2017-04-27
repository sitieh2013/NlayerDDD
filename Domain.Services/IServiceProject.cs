using Domain.Core.Paged;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IServiceProject
    {
        #region Projects
        IEnumerable<Project> GetProject();

        IPage<Project> GetProjectPages(IPageable paged);

        Project FindProject(string cod);

        Project FindProject(int id);

        void CreateProject(Project project);

        Project UpdateProject(Project project);

        void DeleteProject(long project);
        #endregion
    }
}
