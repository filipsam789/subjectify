using Newtonsoft.Json;

namespace Domain.DomainModels;

public class Student : BaseEntity
{
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]

    public Faculty? Faculty { get; set; }
    public Guid FacultyId { get; set; }
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]

    public List<Subject> Subjects { get; set; } = new();
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<Review> Reviews { get; set; } = new();
}