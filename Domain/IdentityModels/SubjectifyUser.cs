using Domain.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Domain.IdentityModels;

public class SubjectifyUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Admin? Admin { get; set; }
    public Guid? AdminId { get; set; }
    public Student? Student { get; set; }
    public Guid? StudentId { get; set; }
}