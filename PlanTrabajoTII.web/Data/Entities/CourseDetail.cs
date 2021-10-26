namespace PlanTrabajoTII.web.Data.Entities
{
    public class CourseDetail : IEntity
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
