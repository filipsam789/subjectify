using Domain.DomainModels;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation;

public class ReviewService : IReviewService
{
    private readonly IRepository<Review> _reviewRepository;

    public ReviewService(IRepository<Review> reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Review> GetReviewByIdAsync(Guid id)
    {
        return await _reviewRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Review>> GetAllReviewsAsync()
    {
        return await _reviewRepository.GetAllAsync();
    }

    public async Task AddReviewAsync(Review review)
    {
        await _reviewRepository.AddAsync(review);
    }

    public async Task UpdateReviewAsync(Review review)
    {
        await _reviewRepository.UpdateAsync(review);
    }

    public async Task DeleteReviewAsync(Guid id)
    {
        await _reviewRepository.DeleteAsync(id);
    }
}
