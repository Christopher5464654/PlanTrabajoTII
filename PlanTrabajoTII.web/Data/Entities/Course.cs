using System.Collections.Generic;

namespace PlanTrabajoTII.web.Data.Entities
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Teacher Teacher { get; set; }
        public Coordinator Coordinator { get; set; }
        public Subject Subject { get; set; }
        public ICollection<CourseDetail> CourseDetails { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Alert> Alerts { get; set; }
    }
}
