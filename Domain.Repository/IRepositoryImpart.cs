using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IRepositoryImpart
    {
        IEnumerable<Impart> GetListAll();
    }
}
