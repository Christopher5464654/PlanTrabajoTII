namespace PlanTrabajoTII.web.Data.Entities
{
    public class Schedule : IEntity
    {
        public int Id { get; set; }
        public WeekDay WeekDay { get; set; }
        public Classroom Classroom { get; set; }
        public Course Course { get; set; }
    }
}
