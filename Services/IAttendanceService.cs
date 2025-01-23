using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Services
{
    public interface IAttendanceService
    {
        Task<AttendanceDto> GetAttendanceByDateAsync(int employeeId, DateTime date);
        Task<IEnumerable<AttendanceDto>> GetAttendancesByEmployeeIdAsync(int employeeId);
        Task CreateAttendanceAsync(AttendanceDto attendanceDto);
        Task UpdateAttendanceAsync(int attendanceId, AttendanceDto attendanceDto);
        Task DeleteAttendanceAsync(int attendanceId);
    }
}
