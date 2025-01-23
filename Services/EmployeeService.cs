using AutoMapper;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Utilities;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return employee == null ? null : _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            var createdEmployee = await _employeeRepository.AddAsync(employee);
            return _mapper.Map<EmployeeDto>(createdEmployee);
        }

        public async Task<EmployeeDto?> UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(id);
            if (existingEmployee == null) return null;

            _mapper.Map(employeeDto, existingEmployee);
            var updatedEmployee = await _employeeRepository.UpdateAsync(existingEmployee);
            return _mapper.Map<EmployeeDto>(updatedEmployee);
        }

        public async Task<ResponseResult> DeleteEmployeeAsync(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);
                if (employee == null)
                    return ResponseResult.NotFound($"Employee with ID {id} not found.");

                await _employeeRepository.DeleteAsync(employee);
                return ResponseResult.Success("Employee deleted successfully");
            }
            catch (Exception)
            {
                return ResponseResult.InternalError("An error occurred while deleting the employee.");
            }
        }
    }
}
