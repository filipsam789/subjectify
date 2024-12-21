namespace Domain.DomainModels;

public class University : BaseEntity
{
    public string Name { get; set; }
    public List<Faculty> Faculties { get; set; } = new();
}