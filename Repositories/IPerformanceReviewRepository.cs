using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Repositories
{
    public interface IPerformanceReviewRepository
    {
        Task<IEnumerable<PerformanceReview>> GetAllReviewsAsync();
        Task<PerformanceReview> GetReviewByIdAsync(int id);
        Task<IEnumerable<PerformanceReview>> GetReviewsByEmployeeIdAsync(string employeeId);
        Task AddReviewAsync(PerformanceReview review);
        Task UpdateReviewAsync(PerformanceReview review);
        Task DeleteReviewAsync(int id);
    }
}
