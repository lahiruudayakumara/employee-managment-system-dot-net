// IAuthService.cs
using EmployeeManagementSystem.Models;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(string fullName, string email, string password, string role);
        Task<string> LoginAsync(string email, string password);
        Task<User> GetCurrentUserAsync(string token);
    }
}