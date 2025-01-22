using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id) ?? throw new KeyNotFoundException($"Department with id {id} not found.");
            return department;
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await GetDepartmentByIdAsync(id);
            if (department == null) return false;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}