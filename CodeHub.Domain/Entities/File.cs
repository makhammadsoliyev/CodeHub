using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class File : Auditable
{
    public string Name { get; set; }
    public long? FolderId { get; set; }
    public Folder Folder { get; set; }
    public string Content { get; set; }
    public string Extension { get; set; }
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
}
