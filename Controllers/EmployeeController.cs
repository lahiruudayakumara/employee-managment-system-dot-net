using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [Authorize(Roles = "Employee,Admin")]
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while retrieving employees: {ex.Message}" });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                if (employee == null) return NotFound($"Employee with ID {id} not found.");
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while retrieving the employee: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var createdEmployee = await _employeeService.CreateEmployeeAsync(employeeDto);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while creating the employee: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employeeDto);
                if (updatedEmployee == null) return NotFound($"Employee with ID {id} not found.");

                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while updating the employee: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var isDeleted = await _employeeService.DeleteEmployeeAsync(id);
                if (isDeleted.Status)
                    return Ok(new { message = isDeleted.Message });

                if (isDeleted.Message.Contains("not found"))
                    return NotFound(new { message = isDeleted.Message });

                return BadRequest(new { message = isDeleted.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"An error occurred while deleting the employee: {ex.Message}" });
            }
        }
    }
}
