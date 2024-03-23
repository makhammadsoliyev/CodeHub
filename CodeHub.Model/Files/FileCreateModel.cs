namespace CodeHub.Model.Files;

public class FileCreateModel
{
    public string Name { get; set; }
    public long? FolderId { get; set; }
    public string Content { get; set; }
    public string Extension { get; set; }
    public long RepositoryId { get; set; }
}