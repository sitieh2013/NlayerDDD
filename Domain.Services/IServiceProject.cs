using Domain.Core.Paged;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IServiceProject
    {
        #region Projects
        IList<Project> GetProject();

        IPage<Project> GetProjectPages(IPageable paged);

        IPage<Project> GetProjectPages(IPageable paged, string searh);

        Project FindProject(string cod);

        Project FindProject(int id);

        Project CreateProject(Project project);

        Project UpdateProject(Project project);

        void DeleteProject(long project);
        #endregion

        #region Impact
        IList<Impart> GetImpart();
        #endregion

        #region Probabilities
        IList<Probability> GetProbabilities();
        #endregion
    }
}
