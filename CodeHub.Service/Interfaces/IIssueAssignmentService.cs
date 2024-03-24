using CodeHub.Model.IssueAssignments;
using CodeHub.Model.Issues;

namespace CodeHub.Service.Interfaces;

public interface IIssueAssignmentService
{
    Task<IssueAssignmentViewModel> CreateAsync(IssueAssignmentCreateModel issue);
    Task<IssueAssignmentViewModel> UpdateAsync(long id, IssueAssignmentUpdateModel issue);
    Task<bool> DeleteAsync(long id);
    Task<IssueAssignmentViewModel> GetByIdAsync(long id);
    Task<IEnumerable<IssueAssignmentViewModel>> GetAllAsync();
}
