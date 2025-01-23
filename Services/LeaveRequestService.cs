using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Enums;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;

namespace EmployeeManagementSystem.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _repository;

        public LeaveRequestService(ILeaveRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateLeaveRequestAsync(LeaveRequestDto leaveRequestDto)
        {
            var leaveRequest = new LeaveRequest
            {
                EmployeeId = leaveRequestDto.EmployeeId,
                StartDate = leaveRequestDto.StartDate,
                EndDate = leaveRequestDto.EndDate,
                Reason = leaveRequestDto.Reason,
                Status = LeaveStatus.Pending
            };
            await _repository.AddAsync(leaveRequest);
        }

        public async Task<bool> UpdateLeaveRequestStatusAsync(int id, LeaveStatus status)
        {
            var leaveRequest = await _repository.GetByIdAsync(id);
            if (leaveRequest == null) return false;

            leaveRequest.Status = status;
            await _repository.UpdateAsync(leaveRequest);
            return true;
        }

        public async Task<bool> DeleteLeaveRequestAsync(int id)
        {
            var leaveRequest = await _repository.GetByIdAsync(id);
            if (leaveRequest == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
