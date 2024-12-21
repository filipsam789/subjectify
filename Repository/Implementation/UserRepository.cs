using Domain.DomainModels;
using Domain.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interface;

namespace Repository.Implementation;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext context;
    private DbSet<SubjectifyUser> entities;
    string errorMessage = string.Empty;

    public UserRepository(ApplicationDbContext context)
    {
        this.context = context;
        entities = context.Set<SubjectifyUser>();
    }
    public IEnumerable<SubjectifyUser> GetAll()
    {
        return entities.AsEnumerable();
    }

    public SubjectifyUser? Get(string id)
    {
        return entities
            .SingleOrDefault(s => s.Id == id);
    }
    
    public SubjectifyUser Insert(SubjectifyUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        var entityEntry = entities.Add(entity);
        context.SaveChanges();
        return entityEntry.Entity;
    }

    public SubjectifyUser Update(SubjectifyUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        var entityEntry = entities.Update(entity);
        context.SaveChanges();
        return entityEntry.Entity;
    }

    public SubjectifyUser Delete(SubjectifyUser entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }
        var entityEntry = entities.Remove(entity);
        context.SaveChanges();
        return entityEntry.Entity;
    }

    public IEnumerable<Student> GetStudents()
    {
        return context.Students.AsEnumerable();
    }

    public Student GetStudent(string id)
    {
        return context.Set<Student>().SingleOrDefault(u => u.Id.ToString() == id);
    } 
}