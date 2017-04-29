using Domain.UnitOfWork;
using Domain.Repository;
using Data.Repository;
using Data.Persistence;
using System.Data.Entity;

namespace Data.UnitOfWork
{
    public class UnitOfWorkContext : IUnitOfWork
    {
        private readonly DbContext _dataBaseContext;

        public UnitOfWorkContext()
        {
            _dataBaseContext = new DataBaseContext();
        }

        private IRepositoryImpart _repositoryImpart;
        public IRepositoryImpart RepositoryImpart
        {
            get { return _repositoryImpart ?? (_repositoryImpart = new RepositoryImpart(_dataBaseContext)); }
        }

        private IRepositoryProbability _repositoryProbability;
        public IRepositoryProbability RepositoryProbability
        {
            get {
                return _repositoryProbability ?? (_repositoryProbability = new RepositoryProbability(_dataBaseContext));
            }
        }

        private IRepositoryProject _repositoryProject;
        public IRepositoryProject RepositoryProject
        {
            get { return _repositoryProject ?? (_repositoryProject = new RepositoryProject(_dataBaseContext)); }
        }

        private IRepositoryRisk _repositoryRisk;
        public IRepositoryRisk RepositoryRisk
        {
            get { return _repositoryRisk ?? (_repositoryRisk = new RepositoryRisk(_dataBaseContext)); }
        }
    }
}
