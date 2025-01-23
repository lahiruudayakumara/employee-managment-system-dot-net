using EmployeeManagementSystem.DTOs;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceReviewsController : ControllerBase
    {
        private readonly IPerformanceReviewService _reviewService;

        public PerformanceReviewsController(IPerformanceReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
                return NotFound();
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] PerformanceReviewDto reviewDto)
        {
            await _reviewService.AddReviewAsync(reviewDto);
            return CreatedAtAction(nameof(GetReview), new { id = reviewDto.Id }, reviewDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] PerformanceReviewDto reviewDto)
        {
            if (id != reviewDto.Id)
                return BadRequest();
            await _reviewService.UpdateReviewAsync(reviewDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
