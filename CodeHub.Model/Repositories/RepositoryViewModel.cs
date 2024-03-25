using CodeHub.Domain.Enums;
using CodeHub.Model.BranchRepositories;
using CodeHub.Model.Commits;
using CodeHub.Model.Folders;
using CodeHub.Model.GitIgnores;
using CodeHub.Model.Issues;
using CodeHub.Model.Licenses;
using CodeHub.Model.Readmes;
using CodeHub.Model.RepositoryStar;

namespace CodeHub.Model.Repositories;

public class RepositoryViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BranchName { get; set; }
    public long UserId { get; set; }
    public RepositoryVisibility Visibility { get; set; }
    public ReadmeViewModel Readme { get; set; }
    public GitIgnoreViewModel GitIgnore { get; set; }
    public LicenseViewModel License { get; set; }
    public RepositoryViewModel Parent { get; set; }

    public IEnumerable<IssueViewModel> Issues { get; set; }
    public IEnumerable<FolderViewModel> Folders { get; set; }
    public IEnumerable<CommitViewModel> Commits { get; set; }
    public IEnumerable<RepositoryStarViewModel> Stars { get; set; }
    public IEnumerable<BranchRepositoryViewModel> BranchRepositories { get; set; }
}
