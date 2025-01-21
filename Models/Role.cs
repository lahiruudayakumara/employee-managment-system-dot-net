using Microsoft.AspNetCore.Identity;

namespace EmployeeManagementSystem.Models
{
    public class ApplicationRole : IdentityRole
    {
        // You can extend IdentityRole with additional properties specific to your application
        public string Description { get; set; } = string.Empty;
    }
}
