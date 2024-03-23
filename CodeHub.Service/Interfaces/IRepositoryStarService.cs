using CodeHub.Model.RepositoryStar;

namespace CodeHub.Service.Interfaces;

public interface IRepositoryStarService
{
    Task<RepositoryStarViewModel> CreateAsync(RepositoryStarCreateModel repositoryStar);
    Task<bool> DeleteAsync(long id);
    Task<RepositoryStarViewModel> GetByIdAsync(long id);
    Task<IEnumerable<RepositoryStarViewModel>> GetAllAsync();
}
