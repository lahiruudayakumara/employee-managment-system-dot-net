using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repositories
{
    public interface IAttendanceRepository
    {
        Task<Attendance> GetAttendanceByDateAsync(int employeeId, DateTime date);
        Task<IEnumerable<Attendance>> GetAttendancesByEmployeeIdAsync(int employeeId);
        Task AddAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int attendanceId);
    }
}