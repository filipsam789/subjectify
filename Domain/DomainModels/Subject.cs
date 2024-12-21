namespace Domain.DomainModels;

public class Subject: BaseEntity
{
    private string Name { get; set; }
    public List<Review> Reviews { get; set; } = new();
    public Faculty Faculty { get; set; }
    public Guid FacultyId { get; set; }
    public List<Professor> Professors { get; set; } = new();
}