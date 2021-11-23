namespace PlanTrabajoTII.web.Controllers.API
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PlanTrabajoTII.web.Data.Repositories;

    [Route("API/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClassroomsController : Controller
    {
        private readonly IClassroomRepository classroomRepository;

        public ClassroomsController(IClassroomRepository classroomRepository)
        {
            this.classroomRepository = classroomRepository;
        }

        [HttpGet]
        public IActionResult GetClassrooms()
        {
            return Ok(this.classroomRepository.GetAll());
        }
    }
}