using Domain.DomainModels;
using Repository.Interface;
using Service.Interface;

namespace Service.Implementation;

public class ProfessorService : IProfessorService
{
    private readonly IRepository<Professor> _professorRepository;

    public ProfessorService(IRepository<Professor> professorRepository)
    {
        _professorRepository = professorRepository;
    }

    public async Task<Professor> GetProfessorByIdAsync(Guid id)
    {
        return await _professorRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
    {
        return await _professorRepository.GetAllAsync();
    }

    public async Task AddProfessorAsync(Professor professor)
    {
        await _professorRepository.AddAsync(professor);
    }

    public async Task UpdateProfessorAsync(Professor professor)
    {
        await _professorRepository.UpdateAsync(professor);
    }

    public async Task DeleteProfessorAsync(Guid id)
    {
        await _professorRepository.DeleteAsync(id);
    }
}
