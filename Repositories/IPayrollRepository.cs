using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repositories
{
    public interface IPayrollRepository
    {
        Task<IEnumerable<Payroll>> GetAllAsync();
        Task<Payroll?> GetByIdAsync(int id);
        Task AddAsync(Payroll payroll);
        Task UpdateAsync(Payroll payroll);
        Task DeleteAsync(int id);
    }
}
