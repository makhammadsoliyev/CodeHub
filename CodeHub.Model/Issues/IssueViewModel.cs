using CodeHub.Domain.Entities;
using CodeHub.Domain.Enums;

namespace CodeHub.Model.Issues;

public class IssueViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public Repository Repository { get; set; }
    public string Description { get; set; }
    public IssueStatus Status { get; set; }
    public User User { get; set; }
}