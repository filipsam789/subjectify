using Domain.DomainModels;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation;

public class UniversityService : IUniversityService
{
    private readonly IRepository<University> _universityRepository;

    public UniversityService(IRepository<University> universityRepository)
    {
        _universityRepository = universityRepository;
    }

    public async Task<University> GetUniversityByIdAsync(Guid id)
    {
        return await _universityRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<University>> GetAllUniversitiesAsync()
    {
        return await _universityRepository.GetAllAsync();
    }

    public async Task AddUniversityAsync(University university)
    {
        await _universityRepository.AddAsync(university);
    }

    public async Task UpdateUniversityAsync(University university)
    {
        await _universityRepository.UpdateAsync(university);
    }

    public async Task DeleteUniversityAsync(Guid id)
    {
        await _universityRepository.DeleteAsync(id);
    }
}
