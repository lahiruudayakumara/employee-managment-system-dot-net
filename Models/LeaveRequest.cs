using System;
using System.ComponentModel.DataAnnotations;
using EmployeeManagementSystem.Enums;

namespace EmployeeManagementSystem.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(200)]
        public string Reason { get; set; } = string.Empty;

        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

        public DateTime DateRequested { get; set; } = DateTime.Now;
    }
}
