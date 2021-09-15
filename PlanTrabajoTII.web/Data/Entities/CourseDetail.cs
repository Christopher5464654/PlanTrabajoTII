using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanTrabajoTII.web.Data.Entities
{
    public class CourseDetail : IEntity
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
