namespace EmployeeManagementSystem.Models
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public Employee? Employee { get; set; } = null!;
        public DateTime ReviewDate { get; set; } = DateTime.Now;
        public int Rating { get; set; } = 0;
        public string ReviewComments { get; set; } = string.Empty;
        public int ManagerId { get; set; } = 0;
        public User? Manager { get; set; } = null!;
    }
}
