using CodeHub.Model.GitIgnores;
using CodeHub.Model.Licenses;
using CodeHub.Model.Readmes;
using CodeHub.Model.Repositories;
using CodeHub.Model.Users;

namespace CodeHub.Model.BranchRepositories;

public class BranchRepositoryViewModel
{
    public long Id { get; set; }
    public string BranchName { get; set; }
    public UserViewModel User { get; set; }
    public RepositoryViewModel Repository { get; set; }
    public ReadmeViewModel Readme { get; set; }
    public GitIgnoreViewModel GitIgnore { get; set; }
    public LicenseViewModel License { get; set; }
}