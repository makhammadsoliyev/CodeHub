using CodeHub.Model.Issues;

namespace CodeHub.Service.Interfaces;

public interface IIssueAssignmentService
{
    Task<IssueViewModel> CreateAsync(IssueCreateModel issue);
    Task<IssueViewModel> UpdateAsync(long id, IssueUpdateModel issue);
    Task<bool> DeleteAsync(long id);
    Task<IssueViewModel> GetById(long id);
    Task<IEnumerable<IssueViewModel>> GetAllAsync();
}
