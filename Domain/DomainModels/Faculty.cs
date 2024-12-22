namespace Domain.DomainModels;

public class Faculty : BaseEntity
{
    public University? University { get; set; }
    public Guid UniversityId { get; set; }
    public string Name { get; set; }
    public List<Subject> Subjects { get; set; } = new();
    public List<Student> Students { get; set; } = new();
    public List<Professor> Professors { get; set; } = new();
}