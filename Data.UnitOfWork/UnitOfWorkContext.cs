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
            get
            {
                if (_repositoryImpart == null)
                {
                    _repositoryImpart = new RepositoryImpart(_dataBaseContext);
                }

                return _repositoryImpart;
            }
        }

        private IRepositoryProbability _repositoryProbability;
        public IRepositoryProbability RepositoryProbability
        {
            get
            {
                if (_repositoryProbability == null)
                {
                    _repositoryProbability = new RepositoryProbability(_dataBaseContext);
                }

                return _repositoryProbability;
            }
        }

        private IRepositoryProject _repositoryProject;
        public IRepositoryProject RepositoryProject
        {
            get
            {
                if (_repositoryProject == null)
                {
                    _repositoryProject = new RepositoryProject(_dataBaseContext);
                }

                return _repositoryProject;
            }
        }

        private IRepositoryRisk _repositoryRisk;
        public IRepositoryRisk RepositoryRisk
        {
            get
            {
                if (_repositoryRisk == null)
                {
                    _repositoryRisk = new RepositoryRisk(_dataBaseContext);
                }

                return _repositoryRisk;
            }
        }
    }
}
