using EmployeeManagementSystem.DTOs;

namespace EmployeeManagementSystem.Services
{
    public interface IPerformanceReviewService
    {
        Task<IEnumerable<PerformanceReviewDto>> GetAllReviewsAsync();
        Task<PerformanceReviewDto> GetReviewByIdAsync(int id);
        Task AddReviewAsync(PerformanceReviewDto reviewDto);
        Task UpdateReviewAsync(PerformanceReviewDto reviewDto);
        Task DeleteReviewAsync(int id);
    }
}
