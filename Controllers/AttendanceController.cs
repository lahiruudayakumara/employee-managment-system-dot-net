using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("{employeeId}/attendance/{date}")]
        public async Task<IActionResult> GetAttendanceByDate(int employeeId, DateTime date)
        {
            var attendance = await _attendanceService.GetAttendanceByDateAsync(employeeId, date);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        [HttpGet("{employeeId}/attendances")]
        public async Task<IActionResult> GetAttendancesByEmployeeId(int employeeId)
        {
            var attendances = await _attendanceService.GetAttendancesByEmployeeIdAsync(employeeId);
            return Ok(attendances);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendance([FromBody] AttendanceDto attendanceDto)
        {
            await _attendanceService.CreateAttendanceAsync(attendanceDto);
            return CreatedAtAction(nameof(GetAttendanceByDate), new { employeeId = attendanceDto.EmployeeId, date = attendanceDto.Date }, attendanceDto);
        }

        [HttpPut("{attendanceId}")]
        public async Task<IActionResult> UpdateAttendance(int attendanceId, [FromBody] AttendanceDto attendanceDto)
        {
            await _attendanceService.UpdateAttendanceAsync(attendanceId, attendanceDto);
            return NoContent();
        }

        [HttpDelete("{attendanceId}")]
        public async Task<IActionResult> DeleteAttendance(int attendanceId)
        {
            await _attendanceService.DeleteAttendanceAsync(attendanceId);
            return NoContent();
        }
    }
}
