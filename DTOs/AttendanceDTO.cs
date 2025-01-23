using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs
{
    public class AttendanceDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Clock-in time is required.")]
        public DateTime ClockInTime { get; set; }

        [Required(ErrorMessage = "Clock-out time is required.")]
        public DateTime ClockOutTime { get; set; }

        [Required]
        public bool IsPresent { get; set; }
    }
}
