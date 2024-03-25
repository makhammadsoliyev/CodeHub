using CodeHub.Model.Folders;
using CodeHub.Model.Repositories;

namespace CodeHub.Model.Files;

public class FileViewModel
{
    public string Name { get; set; }
    public FolderViewModel Folder { get; set; }
    public string Content { get; set; }
    public string Extension { get; set; }
    public RepositoryViewModel Repository { get; set; }
}