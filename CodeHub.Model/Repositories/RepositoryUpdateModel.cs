﻿using CodeHub.Domain.Enums;

namespace CodeHub.Model.Repositories;

public class RepositoryUpdateModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string BranchName { get; set; }
    public RepositoryVisibility Visibility { get; set; }
    public long UserId { get; set; }
    public long? ReadmeId { get; set; }
    public long? GitIgnoreId { get; set; }
    public long? LicenseId { get; set; }
    public long? ParentParentId { get; set; }
}
