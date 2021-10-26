namespace PlanTrabajoTII.web.Data.Repositories
{
    using PlanTrabajoTII.web.Data.Entities;
    public class WeekDayRepository : GenericRepository<WeekDay>, IWeekDayRepository
    {
        public WeekDayRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}