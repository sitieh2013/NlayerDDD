using Domain.Entities;
using Domain.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Core.Paged;
using System;

namespace Data.Repository
{
    public class RepositoryRisk : Repository<Risks>, IRepositoryRisk
    {
        public RepositoryRisk(DbContext context)
            : base(context)
        {
        }

        public RepositoryRisk()
           : base()
        {
        }

        public IEnumerable<Risks> GetListAll()
        {
            return Repository_FindAll().ToList();
        }

        public Risks GetRisks(int id)
        {
            return Repository_FindById(id);
        }

        public void CreateRisks(Risks risksNew)
        {
            Repository_Insert(risksNew);
        }

        public void UpdateRisks(Risks risks)
        {
            Repository_Saves(risks);
        }

        public void DeleteRisks(Risks risks)
        {
            Repository_Delete(risks);
        }

        public IPage<Risks> GetRiskPages(IPageable paged)
        {
            int count;
            var item = BaseRepository_GetPage(i => i.Id, paged.CurrentPage, paged.PageSize, out count);

            return new Page<Risks>(item, paged.CurrentPage, paged.PageSize, count);
        }
    }
}
