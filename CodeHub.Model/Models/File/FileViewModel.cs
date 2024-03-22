using CodeHub.Domain.Entities;
using CodeHub.Model.Models.Folders;

namespace CodeHub.Model.Models.File;

public class FileViewModel
{
    public string Name { get; set; }
    public FolderViewModel Folder { get; set; }
    public string Content { get; set; }
    public string Extension { get; set; }
    public RepositoryViewModel Repository { get; set; }
}
