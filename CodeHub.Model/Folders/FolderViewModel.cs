using CodeHub.Model.Files;
using CodeHub.Model.Repositories;

namespace CodeHub.Model.Folders;

public class FolderViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public FolderViewModel Parent { get; set; }
    public RepositoryViewModel Repository { get; set; }

    public IEnumerable<FileViewModel> Files { get; set; }
}