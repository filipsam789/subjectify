namespace Domain.DomainModels;

public class Review: BaseEntity
{
    public Subject Subject { get; set; }
    public Student Student { get; set; }
    public Guid SubjectId { get; set; }
    public Guid StudentId { get; set; }
    public int Rating { get; set; }
    public string? PositiveComment { get; set; }
    public string? NegativeComment { get; set; }
    public DateTime Timestamp { get; set; }
}