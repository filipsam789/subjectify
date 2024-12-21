using Domain.DomainModels;

namespace Service.Interface;

public interface IReviewService
{
    Task<Review> GetReviewByIdAsync(Guid id);
    Task<IEnumerable<Review>> GetAllReviewsAsync();
    Task AddReviewAsync(Review review);
    Task UpdateReviewAsync(Review review);
    Task DeleteReviewAsync(Guid id);
}
