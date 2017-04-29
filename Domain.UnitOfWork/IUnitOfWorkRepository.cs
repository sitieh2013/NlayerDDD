using Domain.Repository;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        IRepositoryImpart RepositoryImpart { get;}
       
        IRepositoryProbability RepositoryProbability { get; }

        IRepositoryProject RepositoryProject { get; }

        IRepositoryRisk RepositoryRisk { get; }
    }
}
