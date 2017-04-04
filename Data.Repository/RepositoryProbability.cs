using Domain.Entities;
using Domain.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repository
{
    public class RepositoryProbability : Repository<Probability>, IRepositoryProbability
    {
        public RepositoryProbability(DbContext context)
            : base(context)
        {
        }
        public RepositoryProbability()
            : base()
        {
        }

        public IEnumerable<Probability> GetListAll()
        {
            return Repository_FindAll().ToList();
        }
    }
}
