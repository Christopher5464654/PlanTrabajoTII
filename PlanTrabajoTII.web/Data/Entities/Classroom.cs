using System.Collections.Generic;

namespace PlanTrabajoTII.web.Data.Entities
{
    public class Classroom : IEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
