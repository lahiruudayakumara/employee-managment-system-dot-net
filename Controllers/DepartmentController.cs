using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentResponseDto>>> GetDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            if (departments.Count == 0) return NotFound("No departments found.");
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentResponseDto>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound($"Department with ID {id} not found.");
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentResponseDto>> AddDepartment([FromBody] DepartmentDto departmentDTO)
        {
            var department = await _departmentService.AddDepartmentAsync(departmentDTO);
            if (department == null) return BadRequest("Department could not be created.");
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentResponseDto>> UpdateDepartment(int id, [FromBody] DepartmentDto departmentDTO)
        {
            var department = await _departmentService.UpdateDepartmentAsync(id, departmentDTO);
            if (department == null) return NotFound($"Department with ID {id} not found.");
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id);
            if (result.Status)
                return Ok(new { message = result.Message });

            return result.Message.Contains("not found") ? NotFound(result.Message) : BadRequest(result.Message);
        }
    }
}
