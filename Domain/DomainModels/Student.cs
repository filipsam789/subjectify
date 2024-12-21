namespace Domain.DomainModels;

public class Student : BaseEntity
{
    public Faculty Faculty { get; set; }
    public Guid FacultyId { get; set; }
    public List<Subject> Subjects { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}