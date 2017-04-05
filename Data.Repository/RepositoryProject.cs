using Domain.Entities;
using Domain.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Core.Paged;
using System;

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

        public IPage<Project> GetProjectPages(IPageable paged)
        {
            int count;
            var item = BaseRepository_GetPage(i => i.Id, paged.CurrentPage, paged.PageSize, out count);

            return new Page<Project>(item, paged.CurrentPage, paged.PageSize, count);
        }
    }
}
