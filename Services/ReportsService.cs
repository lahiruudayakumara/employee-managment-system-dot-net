using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public class ReportsService : IReportsService
    {
        private readonly ApplicationDbContext _context;

        public ReportsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesReportAsync()
        {
            return await _context.Employees
                .Where(e => e.IsActive)
                .ToListAsync();
        }

        public async Task<List<Attendance>> GetAttendanceReportAsync(int employeeId)
        {
            return await _context.Attendance
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsReportAsync(int employeeId)
        {
            return await _context.LeaveRequests
                .Where(l => l.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<List<Payroll>> GetPayrollReportAsync(int employeeId)
        {
            return await _context.Payrolls
                .Where(p => p.EmployeeId == employeeId)
                .ToListAsync();
        }
    }
}
