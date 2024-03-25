using CodeHub.Model.BranchRepositories;

namespace CodeHub.Service.Interfaces;

public interface IBranchRepositoryService
{
    /// <summary>
    /// Create a new branchRepository
    /// </summary>
    /// <param name="branchRepository"></param>
    /// <returns></returns>
    Task<BranchRepositoryViewModel> CreateAsync(BranchRepositoryCreateModel branchRepository);

    /// <summary>
    /// Update an exist branchRepository
    /// </summary>
    /// <param name="id"></param>
    /// <param name="branchRepository"></param>
    /// <returns></returns>
    Task<BranchRepositoryViewModel> UpdateAsync(long id, BranchRepositoryUpdateModel branchRepository);

    /// <summary>
    /// Delete an exist branchRepository via id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(long id);

    /// <summary>
    /// Retrieve an exist branchRepository via id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BranchRepositoryViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Retrieve list of branchRepositories
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<BranchRepositoryViewModel>> GetAllAsync();
}
