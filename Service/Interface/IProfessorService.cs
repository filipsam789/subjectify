using Domain.DomainModels;

namespace Service.Interface;

public interface IProfessorService
{
    Task<Professor> GetProfessorByIdAsync(Guid id);
    Task<IEnumerable<Professor>> GetAllProfessorsAsync();
    Task AddProfessorAsync(Professor professor);
    Task UpdateProfessorAsync(Professor professor);
    Task DeleteProfessorAsync(Guid id);
}