using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepository _payrollRepository;

        public PayrollService(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<IEnumerable<Payroll>> GetAllPayrollsAsync()
        {
            return await _payrollRepository.GetAllAsync();
        }

        public async Task<Payroll?> GetPayrollByIdAsync(int id)
        {
            return await _payrollRepository.GetByIdAsync(id);
        }

        public async Task AddPayrollAsync(Payroll payroll)
        {
            if (payroll.EmployeeId <= 0)
            {
                throw new ArgumentException("Invalid EmployeeId.");
            }

            payroll.TotalSalary = payroll.BasicSalary + payroll.Bonus - payroll.Deductions; // Business logic
            await _payrollRepository.AddAsync(payroll);
        }

        public async Task UpdatePayrollAsync(Payroll payroll)
        {
            if (payroll.EmployeeId <= 0)
            {
                throw new ArgumentException("Invalid EmployeeId.");
            }

            payroll.TotalSalary = payroll.BasicSalary + payroll.Bonus - payroll.Deductions; // Business logic
            await _payrollRepository.UpdateAsync(payroll);
        }

        public async Task DeletePayrollAsync(int id)
        {
            await _payrollRepository.DeleteAsync(id);
        }
    }
}
