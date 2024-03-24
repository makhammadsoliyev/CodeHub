using CodeHub.Domain.Entities;
using CodeHub.Model.Repositories;

namespace CodeHub.Model.Folders;

public class FolderViewModel
{
    public string Name { get; set; }
    public FolderViewModel Parent { get; set; }
    public RepositoryViewModel Repository { get; set; }
}
