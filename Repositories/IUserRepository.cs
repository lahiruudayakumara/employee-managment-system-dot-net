using EmployeeManagementSystem.Models;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> UserExistsByEmailAsync(string email);
    }
}