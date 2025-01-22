using AutoMapper;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartmentResponseDto>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return _mapper.Map<List<DepartmentResponseDto>>(departments);
        }

        public async Task<DepartmentResponseDto> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            return _mapper.Map<DepartmentResponseDto>(department);
        }

        public async Task<DepartmentResponseDto> AddDepartmentAsync(DepartmentDto departmentDTO)
        {
            var department = _mapper.Map<Department>(departmentDTO);
            var createdDepartment = await _departmentRepository.AddDepartmentAsync(department);
            return _mapper.Map<DepartmentResponseDto>(createdDepartment);
        }

        public async Task<DepartmentResponseDto?> UpdateDepartmentAsync(int id, DepartmentDto departmentDTO)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(id);
            if (department == null) return null;

            _mapper.Map(departmentDTO, department);
            var updatedDepartment = await _departmentRepository.UpdateDepartmentAsync(department);
            return _mapper.Map<DepartmentResponseDto>(updatedDepartment);
        }

        public async Task<ResponseResult> DeleteDepartmentAsync(int id)
        {
            try {
                var result = await _departmentRepository.DeleteDepartmentAsync(id);
                return result ? ResponseResult.Success("Department deleted successfully.") : ResponseResult.NotFound($"Department with ID {id} not found.");
            } catch {
                return ResponseResult.NotFound("An error occurred while deleting the department.");
            }
        }
    }
}
