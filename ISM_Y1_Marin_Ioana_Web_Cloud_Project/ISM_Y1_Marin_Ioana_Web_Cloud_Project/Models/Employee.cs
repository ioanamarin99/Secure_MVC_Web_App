using System.ComponentModel.DataAnnotations.Schema;

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal EmployeeWage { get; set; }
        public List<Job>? Jobs { get; set; }

    }
}
