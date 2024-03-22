namespace CodeHub.Model.Models.Folders;

public class FolderCreateModel
{
    public string Name { get; set; }
    public long ParentId { get; set; }
    public long RepositoryId { get; set; }
}