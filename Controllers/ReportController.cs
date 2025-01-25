using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployeesReport()
        {
            var report = await _reportsService.GetEmployeesReportAsync();
            return Ok(report);
        }

        [HttpGet("attendance/{employeeId}")]
        public async Task<IActionResult> GetAttendanceReport(int employeeId)
        {
            var report = await _reportsService.GetAttendanceReportAsync(employeeId);
            return Ok(report);
        }

        [HttpGet("leaves/{employeeId}")]
        public async Task<IActionResult> GetLeaveRequestsReport(int employeeId)
        {
            var report = await _reportsService.GetLeaveRequestsReportAsync(employeeId);
            return Ok(report);
        }

        [HttpGet("payroll/{employeeId}")]
        public async Task<IActionResult> GetPayrollReport(int employeeId)
        {
            var report = await _reportsService.GetPayrollReportAsync(employeeId);
            return Ok(report);
        }
    }
}
