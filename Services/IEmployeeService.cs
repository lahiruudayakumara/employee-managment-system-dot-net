using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto);
        Task<EmployeeDto?> UpdateEmployeeAsync(int id, EmployeeDto employeeDto);
        Task<ResponseResult> DeleteEmployeeAsync(int id);
    }
}
