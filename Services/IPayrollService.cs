using EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public interface IPayrollService
    {
        Task<IEnumerable<Payroll>> GetAllPayrollsAsync();
        Task<Payroll?> GetPayrollByIdAsync(int id);
        Task AddPayrollAsync(Payroll payroll);
        Task UpdatePayrollAsync(Payroll payroll);
        Task DeletePayrollAsync(int id);
    }
}