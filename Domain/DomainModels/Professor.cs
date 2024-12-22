namespace Domain.DomainModels;

public class Professor: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    
    public List<Subject> Subjects { get; set; } = new();
    public Faculty? Faculty { get; set; }
    public Guid FacultyId { get; set; }
}