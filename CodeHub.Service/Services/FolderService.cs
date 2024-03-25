using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.Folders;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class FolderService : IFolderService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<Folder> repository;

    public FolderService(IMapper mapper, IGenericRepository<Folder> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<FolderViewModel> CreateAsync(FolderCreateModel folder)
    {
        var createdFolder = await repository.InsertAsync(mapper.Map<Folder>(folder));
        await repository.SaveAsync();

        return mapper.Map<FolderViewModel>(createdFolder);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existFolder = await repository.SelectByIdAsync(id, new string[] { "Files" })
            ?? throw new CustomException(404, "Folder not found");

        await repository.DeleteAsync(existFolder);
        await repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<FolderViewModel>> GetAllAsync()
    {
        var folders = await repository.SelectAsQueryable(new string[] { "Files" }).ToListAsync();
        return mapper.Map<IEnumerable<FolderViewModel>>(folders);
    }

    public async Task<FolderViewModel> GetByIdAsync(long id)
    {
        var existFolder = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Folder not found");

        return mapper.Map<FolderViewModel>(existFolder);
    }

    public async Task<FolderViewModel> UpdateAsync(long id, FolderUpdateModel folder)
    {
        var existFolder = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Folder not found");

        var mappedFolder = mapper.Map(folder, existFolder);
        var updateFolder = await repository.UpdateAsync(mappedFolder);

        return mapper.Map<FolderViewModel>(updateFolder);
    }
}
