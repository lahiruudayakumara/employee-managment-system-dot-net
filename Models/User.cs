using System.ComponentModel.DataAnnotations;
using EmployeeManagementSystem.Enums;
namespace EmployeeManagementSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
