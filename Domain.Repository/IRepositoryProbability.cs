using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IRepositoryProbability
    {
        IEnumerable<Probability> GetListAll();
    }
}
