namespace EmployeeManagementSystem.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public bool IsPresent { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
