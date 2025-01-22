using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentResponseDto>> GetAllDepartmentsAsync();
        Task<DepartmentResponseDto> GetDepartmentByIdAsync(int id);
        Task<DepartmentResponseDto> AddDepartmentAsync(DepartmentDto departmentDTO);
        Task<DepartmentResponseDto> UpdateDepartmentAsync(int id, DepartmentDto departmentDTO);
        Task<ResponseResult> DeleteDepartmentAsync(int id);
    }
}