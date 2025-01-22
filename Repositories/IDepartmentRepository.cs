using EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repositories
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}
