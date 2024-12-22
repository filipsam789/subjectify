using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Domain.DomainModels;

public class Subject: BaseEntity
{
    public string Name { get; set; }
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]

    public List<Review> Reviews { get; set; } = new();
    
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public Faculty? Faculty { get; set; }
    public Guid FacultyId { get; set; }
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<Professor> Professors { get; set; } = new();
}