using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Services
{
    public interface IReportsService
    {
        Task<List<Employee>> GetEmployeesReportAsync();
        Task<List<Attendance>> GetAttendanceReportAsync(int employeeId);
        Task<List<LeaveRequest>> GetLeaveRequestsReportAsync(int employeeId);
        Task<List<Payroll>> GetPayrollReportAsync(int employeeId);
    }
}
