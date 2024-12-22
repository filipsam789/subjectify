using Newtonsoft.Json;

namespace Domain.DomainModels;

public class University : BaseEntity
{
    public string Name { get; set; }
    [JsonProperty(ReferenceLoopHandling = ReferenceLoopHandling.Ignore)]
    public List<Faculty> Faculties { get; set; } = new();
}