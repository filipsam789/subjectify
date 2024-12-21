using Domain.DomainModels;

namespace Service.Interface;

public interface IStudentService
{
    Task<Student> GetStudentByIdAsync(Guid id);
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task AddStudentAsync(Student student);
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(Guid id);
}