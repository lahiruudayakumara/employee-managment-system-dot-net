using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Enums;
using EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync();
        Task<LeaveRequest?> GetLeaveRequestByIdAsync(int id);
        Task CreateLeaveRequestAsync(LeaveRequestDto leaveRequestDto);
        Task<bool> UpdateLeaveRequestStatusAsync(int id, LeaveStatus status);
        Task<bool> DeleteLeaveRequestAsync(int id);
    }
}
