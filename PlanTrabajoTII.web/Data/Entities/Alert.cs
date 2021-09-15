namespace PlanTrabajoTII.web.Data.Entities
{
    public class Alert : IEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Course Course { get; set; }
    }
}
