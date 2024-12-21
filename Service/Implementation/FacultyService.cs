using Domain.DomainModels;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation;

public class FacultyService : IFacultyService
{
    private readonly IRepository<Faculty> _facultyRepository;

    public FacultyService(IRepository<Faculty> facultyRepository)
    {
        _facultyRepository = facultyRepository;
    }

    public async Task<Faculty> GetFacultyByIdAsync(Guid id)
    {
        return await _facultyRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Faculty>> GetAllFacultiesAsync()
    {
        return await _facultyRepository.GetAllAsync();
    }

    public async Task AddFacultyAsync(Faculty faculty)
    {
        await _facultyRepository.AddAsync(faculty);
    }

    public async Task UpdateFacultyAsync(Faculty faculty)
    {
        await _facultyRepository.UpdateAsync(faculty);
    }

    public async Task DeleteFacultyAsync(Guid id)
    {
        await _facultyRepository.DeleteAsync(id);
    }
}
