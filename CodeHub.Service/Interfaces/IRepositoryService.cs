using CodeHub.Model.Repositories;

namespace CodeHub.Service.Interfaces;

public interface IRepositoryService
{
    Task<RepositoryViewModel> CreateAsync(RepositoryCreateModel repository);
    Task<RepositoryViewModel> UpdateAsync(long id, RepositoryUpdateModel repository);
    Task<bool> DeleteAsync(long id);
    Task<RepositoryViewModel> GetByIdAsync(long id);
    Task<IEnumerable<RepositoryViewModel>> GetAllAsync();
}
