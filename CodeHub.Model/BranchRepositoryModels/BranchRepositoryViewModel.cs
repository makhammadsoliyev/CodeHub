﻿namespace CodeHub.Model.BranchRepositoryModels;

public class BranchRepositoryViewModel
{
    public long ID { get; set; }
    public string BranchName { get; set; }
    public long UserID { get; set; }
    public long RepositoryId { get; set; }
    public long? ReadmeID { get; set; }
    public long? GitIgnoreID { get; set; }
    public long? LicenceID { get; set; }
}
