using Domain.DomainModels;
using Domain.IdentityModels;

namespace Repository.Interface;

public interface IUserRepository
{
    IEnumerable<SubjectifyUser> GetAll();
    SubjectifyUser? Get(string? id);
    SubjectifyUser Insert(SubjectifyUser entity);
    SubjectifyUser Update(SubjectifyUser entity);
    SubjectifyUser Delete(SubjectifyUser entity);
    public Student? GetStudent(string id);
    public IEnumerable<Student> GetStudents();

}