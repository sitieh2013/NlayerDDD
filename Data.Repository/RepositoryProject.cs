using Domain.Entities;
using Domain.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repository
{
    public class RepositoryProject : Repository<Project>, IRepositoryProject
    {
        public RepositoryProject(DbContext context)
            : base(context)
        {
        }
        public RepositoryProject()
            : base()
        {
        }

        public IEnumerable<Project> GetListAll()
        {
            return Repository_FindAll();
        }

        public Project GetProject(string code)
        {
            return Repository_Find(i => i.Cod == code).FirstOrDefault();
        }

        public void CreateProject(Project projectNew)
        {
            Repository_Insert(projectNew);
        }

        public void UpdateProject(Project project)
        {
            Repository_Saves(project);
        }
    }
}
