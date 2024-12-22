using Newtonsoft.Json;

namespace Domain.DomainModels;

public class Professor: BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    
    public List<Subject> Subjects { get; set; } = new();
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public Faculty? Faculty { get; set; }
    public Guid FacultyId { get; set; }
}