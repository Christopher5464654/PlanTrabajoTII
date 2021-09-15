using System.Collections.Generic;

namespace PlanTrabajoTII.web.Data.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<CourseDetail> DetailCourses { get; set; }
    }
}