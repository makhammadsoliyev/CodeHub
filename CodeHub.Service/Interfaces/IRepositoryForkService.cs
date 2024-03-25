using CodeHub.Model.RepositroyForks;

namespace CodeHub.Service.Interfaces;

public interface IRepositoryForkService
{
    Task<RepositoryForkViewModel> CreateAsync(RepositoryForkCreateModel fork);
    Task<bool> DeleteAsync(long id);
    Task<RepositoryForkViewModel> GetByIdAsync(long id);
    Task<IEnumerable<RepositoryForkViewModel>> GetAllAsync();
}
