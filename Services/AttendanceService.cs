using AutoMapper;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;

namespace EmployeeManagementSystem.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<AttendanceDto> GetAttendanceByDateAsync(int employeeId, DateTime date)
        {
            var attendance = await _attendanceRepository.GetAttendanceByDateAsync(employeeId, date);
            return _mapper.Map<AttendanceDto>(attendance);
        }

        public async Task<IEnumerable<AttendanceDto>> GetAttendancesByEmployeeIdAsync(int employeeId)
        {
            var attendances = await _attendanceRepository.GetAttendancesByEmployeeIdAsync(employeeId);
            return _mapper.Map<IEnumerable<AttendanceDto>>(attendances);
        }

        public async Task CreateAttendanceAsync(AttendanceDto attendanceDto)
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            await _attendanceRepository.AddAttendanceAsync(attendance);
        }

        public async Task UpdateAttendanceAsync(int attendanceId, AttendanceDto attendanceDto)
        {
            var attendance = await _attendanceRepository.GetAttendanceByDateAsync(attendanceId, attendanceDto.Date);
            if (attendance != null)
            {
                attendance.ClockInTime = attendanceDto.ClockInTime;
                attendance.ClockOutTime = attendanceDto.ClockOutTime;
                attendance.IsPresent = attendanceDto.IsPresent;
                await _attendanceRepository.UpdateAttendanceAsync(attendance);
            }
        }

        public async Task DeleteAttendanceAsync(int attendanceId)
        {
            await _attendanceRepository.DeleteAttendanceAsync(attendanceId);
        }
    }
}