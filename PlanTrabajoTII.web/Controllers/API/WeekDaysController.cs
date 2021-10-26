namespace PlanTrabajoTII.web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using PlanTrabajoTII.web.Data.Repositories;
    using System;

    [Route("API/[Controller]")]
    public class WeekDaysController : Controller
    {
        private readonly IWeekDayRepository weekDayRepository;

        public WeekDaysController(IWeekDayRepository weekDayRepository)
        {
            this.weekDayRepository = weekDayRepository;
        }

        [HttpGet]
        public IActionResult GetWeekDays()
        {
            return Ok(this.weekDayRepository.GetAll());
        }
    }
}
