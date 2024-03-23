using CodeHub.Domain.Commons;

namespace CodeHub.Domain.Entities;

public class Folder : Auditable
{
    public string Name { get; set; }
    public long? ParentId { get; set; }
    public Folder Parent { get; set; }
    public long RepositoryId { get; set; }
    public Repository Repository { get; set; }
}
