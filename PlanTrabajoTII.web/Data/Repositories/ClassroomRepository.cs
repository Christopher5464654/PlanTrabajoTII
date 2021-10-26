namespace PlanTrabajoTII.web.Data.Repositories
{
    using PlanTrabajoTII.web.Data.Entities;

    public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}