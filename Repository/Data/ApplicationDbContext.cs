using Domain.DomainModels;
using Domain.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data;

public class ApplicationDbContext : IdentityDbContext<SubjectifyUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Professor> Professors { get; set; }
    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<Subject> Subjects { get; set; }
    public virtual DbSet<Faculty> Faculties { get; set; }
    public virtual DbSet<University> Universities { get; set; }
    public virtual DbSet<Review> Reviews { get; set; }
    public virtual DbSet<SubjectifyUser> SubjectifyUsers { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<ReviewRequest> ReviewRequests { get; set; }
}