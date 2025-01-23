using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagementSystem.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance> GetAttendanceByDateAsync(int employeeId, DateTime date)
        {
            return await _context.Attendance
                .FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.Date == date) ?? throw new InvalidOperationException("Attendance not found");
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesByEmployeeIdAsync(int employeeId)
        {
            return await _context.Attendance
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _context.Attendance.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            _context.Attendance.Update(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttendanceAsync(int attendanceId)
        {
            var attendance = await _context.Attendance.FindAsync(attendanceId);
            if (attendance != null)
            {
                _context.Attendance.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }
    }
}