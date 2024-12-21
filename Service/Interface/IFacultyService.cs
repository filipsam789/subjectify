using Domain.DomainModels;

namespace Service.Interface;

public interface IFacultyService
{
    Task<Faculty> GetFacultyByIdAsync(Guid id);
    Task<IEnumerable<Faculty>> GetAllFacultiesAsync();
    Task AddFacultyAsync(Faculty faculty);
    Task UpdateFacultyAsync(Faculty faculty);
    Task DeleteFacultyAsync(Guid id);
}