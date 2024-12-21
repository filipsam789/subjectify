using Domain.DomainModels;

namespace Service.Interface;

public interface IUniversityService
{
    Task<University> GetUniversityByIdAsync(Guid id);
    Task<IEnumerable<University>> GetAllUniversitiesAsync();
    Task AddUniversityAsync(University university);
    Task UpdateUniversityAsync(University university);
    Task DeleteUniversityAsync(Guid id);
}