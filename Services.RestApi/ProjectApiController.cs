using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Domain.Entities;
using Domain.Services;

namespace Services.RestApi
{
    public class ProjectApiController: ApiController
    {
        private readonly IServiceProject _serviceProject;
        private readonly MapJson<Entity> _mapJson;

        public ProjectApiController(IServiceProject serviceProject)
        {
            _serviceProject = serviceProject;
            _mapJson = new MapJson<Entity>();
        }

        // GET: api/project/get
        public IEnumerable<Project> Get()
        {
            return _serviceProject.GetProject();
        }

        // GET: api/project/getall
        public string GetAll()
        {
            var lista = new List<Entity>(_serviceProject.GetProject().ToList());
            return _mapJson.MapJsonSerialize(lista);
        }

        // POST api/project/post
        [ResponseType(typeof (Project))]
        public IHttpActionResult Post(Project project)
        {
            _serviceProject.CreateProject(project);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }
    }
}
