using CodeHub.Model.BranchRepositories;

namespace CodeHub.Service.Interfaces;

public interface IBranchRepositoryService
{
    Task<BranchRepositoryViewModel> CreateAsync(BranchRepositoryCreateModel branchRepository);
    Task<BranchRepositoryViewModel> UpdateAsync(long id, BranchRepositoryUpdateModel branchRepository);
    Task<bool> DeleteAsync(long id);
    Task<BranchRepositoryViewModel> GetByIdAsync(long id);
    Task<IEnumerable<BranchRepositoryViewModel>> GetAllAsync();
}
