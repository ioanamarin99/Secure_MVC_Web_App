using ISM_Y1_Marin_Ioana_Web_Cloud_Project.Models;

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Data
{
    public interface IRepository
    {
        IQueryable<Employee> Employees { get;}

    }
}
