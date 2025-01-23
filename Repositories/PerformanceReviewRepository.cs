using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories
{
    public class PerformanceReviewRepository : IPerformanceReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public PerformanceReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PerformanceReview>> GetAllReviewsAsync()
        {
            return await _context.PerformanceReviews
                .Include(r => r.Employee)
                .Include(r => r.Manager)
                .ToListAsync();
        }

        public async Task<PerformanceReview> GetReviewByIdAsync(int id)
        {
            var review = await _context.PerformanceReviews
                .Include(r => r.Employee)
                .Include(r => r.Manager)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (review == null)
            {
                throw new KeyNotFoundException($"Performance review with id {id} not found.");
            }

            return review;
        }

        public async Task<IEnumerable<PerformanceReview>> GetReviewsByEmployeeIdAsync(string employeeId)
        {
            return await _context.PerformanceReviews
                .Where(r => r.EmployeeId == employeeId)
                .Include(r => r.Employee)
                .Include(r => r.Manager)
                .ToListAsync();
        }

        public async Task AddReviewAsync(PerformanceReview review)
        {
            await _context.PerformanceReviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(PerformanceReview review)
        {
            _context.PerformanceReviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.PerformanceReviews.FindAsync(id);
            if (review != null)
            {
                _context.PerformanceReviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
