using Domain.DomainModels;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> _studentRepository;

    public StudentService(IRepository<Student> studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Student> GetStudentByIdAsync(Guid id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _studentRepository.GetAllAsync();
    }

    public async Task AddStudentAsync(Student student)
    {
        await _studentRepository.AddAsync(student);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        await _studentRepository.UpdateAsync(student);
    }

    public async Task DeleteStudentAsync(Guid id)
    {
        await _studentRepository.DeleteAsync(id);
    }
}
