﻿using System.Collections.Generic;

namespace PlanTrabajoTII.web.Data.Entities
{
    public class Coordinator : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}