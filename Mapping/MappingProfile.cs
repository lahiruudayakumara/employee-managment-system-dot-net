using AutoMapper;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Attendance, AttendanceDto>();
            CreateMap<AttendanceDto, Attendance>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentResponseDto>();
            CreateMap<LeaveRequest, LeaveRequestDto>();
            CreateMap<LeaveRequestDto, LeaveRequest>();
            CreateMap<Payroll, PayrollDto>();
            CreateMap<PayrollDto, Payroll>();
            CreateMap<PerformanceReview, PerformanceReviewDto>();
            CreateMap<PerformanceReviewDto, PerformanceReview>();
        }
    }
}
