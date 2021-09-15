using System.Collections.Generic;

namespace PlanTrabajoTII.web.Data.Entities
{
    public class Subject : IEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
