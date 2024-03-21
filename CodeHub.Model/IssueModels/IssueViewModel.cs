using CodeHub.Domain.Entities;
using CodeHub.Domain.Enums;

namespace CodeHub.Model.IssueModels;

public class IssueViewModel
{
    public long ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public IssueStatus Status { get; set; }
    public long RepositoryID { get; set; }
    public User User { get; set; }
}