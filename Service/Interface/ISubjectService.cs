using Domain.DomainModels;

namespace Service.Interface;

public interface ISubjectService
{
    Task<Subject> GetSubjectByIdAsync(Guid id);
    Task<IEnumerable<Subject>> GetAllSubjectsAsync();
    Task AddSubjectAsync(Subject subject);
    Task UpdateSubjectAsync(Subject subject);
    Task DeleteSubjectAsync(Guid id);
}