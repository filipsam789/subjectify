namespace Domain.DomainModels;

public class ReviewRequest : BaseEntity
{
    public Review? Review { get; set; }
    public Guid ReviewId { get; set; }
}