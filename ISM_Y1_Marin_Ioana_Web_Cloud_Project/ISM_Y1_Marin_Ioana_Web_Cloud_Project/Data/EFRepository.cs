using ISM_Y1_Marin_Ioana_Web_Cloud_Project.Models;

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Data
{
    public class EFRepository : IRepository
    {
        private ApplicationDBContext context;
        public EFRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Employee> Employees {
            get { return context.employees; }
        }
    }
}
