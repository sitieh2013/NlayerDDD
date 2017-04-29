using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Services;
using Newtonsoft.Json;

namespace Services.RestApi
{
    public class ProjectApiController: ApiController
    {
        private readonly IServiceProject _serviceProject;
        private readonly MapJson<Project> _mapJson;

        public ProjectApiController(IServiceProject serviceProject)
        {
            _serviceProject = serviceProject;
            _mapJson = new MapJson<Project>();
        }

        // POST api/projectapi/getall
        public JsonResult<List<Project>> GetAll()
        {
            var temp = _serviceProject.GetProject().ToList();
            return _mapJson.MapJsonSerializeList(temp);
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
