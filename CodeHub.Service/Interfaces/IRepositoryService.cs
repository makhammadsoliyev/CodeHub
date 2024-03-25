using CodeHub.Model.Repositories;

namespace CodeHub.Service.Interfaces;

public interface IRepositoryService
{
    /// <summary>
    /// Create new a repository
    /// </summary>
    /// <param name="repository"></param>
    /// <returns></returns>
    Task<RepositoryViewModel> CreateAsync(RepositoryCreateModel repository);

    /// <summary>
    /// Update en exist repository
    /// </summary>
    /// <param name="id"></param>
    /// <param name="repository"></param>
    /// <returns></returns>
    Task<RepositoryViewModel> UpdateAsync(long id, RepositoryUpdateModel repository);

    /// <summary>
    /// Delete an exist repository via id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// Retrieve en exist repository via id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RepositoryViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Retrieve list of repositories
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<RepositoryViewModel>> GetAllAsync();
}
