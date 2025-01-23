using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.DTOs
{
    public class CreatePerformanceReviewDto
    {
        [Required(ErrorMessage = "Employee ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Employee ID must be a positive number.")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 (lowest) and 5 (highest).")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Review comments are required.")]
        [StringLength(500, ErrorMessage = "Review comments cannot exceed 500 characters.")]
        public string ReviewComments { get; set; } = string.Empty;
    }
}
