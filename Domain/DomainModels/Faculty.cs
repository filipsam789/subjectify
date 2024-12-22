using Newtonsoft.Json;

namespace Domain.DomainModels;

public class Faculty : BaseEntity
{
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public University? University { get; set; }
    public Guid UniversityId { get; set; }
    public string Name { get; set; }
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<Subject> Subjects { get; set; } = new();
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    
    public List<Student> Students { get; set; } = new();
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<Professor> Professors { get; set; } = new();
}