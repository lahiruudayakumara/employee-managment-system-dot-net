using AutoMapper;
using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;

namespace EmployeeManagementSystem.Services
{
    public class PerformanceReviewService : IPerformanceReviewService
    {
        private readonly IPerformanceReviewRepository _reviewRepository;
        private readonly IMapper _mapper; // Assuming AutoMapper is used

        public PerformanceReviewService(IPerformanceReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PerformanceReviewDto>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllReviewsAsync();
            return _mapper.Map<IEnumerable<PerformanceReviewDto>>(reviews);
        }

        public async Task<PerformanceReviewDto> GetReviewByIdAsync(int id)
        {
            var review = await _reviewRepository.GetReviewByIdAsync(id);
            return _mapper.Map<PerformanceReviewDto>(review);
        }

        public async Task AddReviewAsync(PerformanceReviewDto reviewDto)
        {
            var review = _mapper.Map<PerformanceReview>(reviewDto);
            await _reviewRepository.AddReviewAsync(review);
        }

        public async Task UpdateReviewAsync(PerformanceReviewDto reviewDto)
        {
            var review = _mapper.Map<PerformanceReview>(reviewDto);
            await _reviewRepository.UpdateReviewAsync(review);
        }

        public async Task DeleteReviewAsync(int id)
        {
            await _reviewRepository.DeleteReviewAsync(id);
        }
    }
}
