namespace CodeHub.Model.Models.Folders;

public class FolderUpdateModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long ParentId { get; set; }
    public long RepositoryId { get; set; }

}
