namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public int WeeklyHours { get; set; }

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

    }
}
