using System.Collections.Generic;

namespace EmployeeManagementSystem.Models
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }
        public string Token { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
