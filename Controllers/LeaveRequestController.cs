using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Enums;
using EmployeeManagementSystem.Services;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/leave-requests")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaveRequests = await _leaveRequestService.GetAllLeaveRequestsAsync();
            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leaveRequest = await _leaveRequestService.GetLeaveRequestByIdAsync(id);
            if (leaveRequest == null)
                return NotFound();

            return Ok(leaveRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LeaveRequestDto leaveRequestDto)
        {
            await _leaveRequestService.CreateLeaveRequestAsync(leaveRequestDto);
            return CreatedAtAction(nameof(GetById), new { id = leaveRequestDto.EmployeeId }, leaveRequestDto);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] LeaveStatus status)
        {
            var updated = await _leaveRequestService.UpdateLeaveRequestStatusAsync(id, status);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _leaveRequestService.DeleteLeaveRequestAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
