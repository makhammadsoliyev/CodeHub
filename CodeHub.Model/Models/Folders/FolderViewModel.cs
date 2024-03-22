using CodeHub.Domain.Entities;

namespace CodeHub.Model.Models.Folders;

public class FolderViewModel
{
    public string Name { get; set; }
    public FolderViewModel Parent { get; set; } 
    public RepositoryViewModel Repository { get; set; }
}
