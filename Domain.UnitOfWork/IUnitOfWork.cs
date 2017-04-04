using Domain.Repository;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepositoryImpart RepositoryImpart { get; set; }
       
        IRepositoryProbability RepositoryProbability { get; set; }

        IRepositoryProject RepositoryProject { get; set; }

        IRepositoryRisk RepositoryRisk { get; set; }

        void SaveChanges();
    }
}
