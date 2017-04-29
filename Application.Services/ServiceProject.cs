using Domain.Services;
using Domain.Entities;
using Domain.Core.Paged;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class ServiceProject : IServiceProject
    {
        private readonly IUnitOfWorkRepository _unit;

        public ServiceProject(IUnitOfWorkRepository unit)
        {
            _unit = unit;
        }

        public void CreateProject(Project project)
        {
            if (FindProject(project.Cod) != null)
                throw new Exception("This project exists!");

            _unit.RepositoryProject.CreateProject(project);
        }

        public void DeleteProject(long project)
        {
            throw new NotImplementedException();
        }

        public Project FindProject(int id)
        {
            throw new NotImplementedException();
        }

        public Project FindProject(string cod)
        {
            return _unit.RepositoryProject.GetProject(cod);
        }

        public IEnumerable<Project> GetProject()
        {
            return _unit.RepositoryProject.GetListAll();
        }

        public IPage<Project> GetProjectPages(IPageable paged)
        {
            return _unit.RepositoryProject.GetProjectPages(paged);
        }

        public Project UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
