using Domain.Entities;
using Domain.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repository
{
    public class RepositoryImpart : Repository<Impart>, 
                                    IRepositoryImpart
    {
        public RepositoryImpart(DbContext context) : base(context)
        {
        }
        public RepositoryImpart() : base()
        {
        }

        public IEnumerable<Impart> GetListAll()
        {
            return Repository_FindAll().ToList();
        }
    }
}
