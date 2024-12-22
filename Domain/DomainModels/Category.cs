namespace Domain.DomainModels;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public List<Subject> Subjects {get; set; }
}