using Domain.Entities;
using Domain.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public List<Risks> GetListAll()
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
    }
}
