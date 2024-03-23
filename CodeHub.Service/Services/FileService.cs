using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.Files;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using File = CodeHub.Domain.Entities.File;

namespace CodeHub.Service.Services;

public class FileService : IFileService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<File> repository;
    public FileService(IGenericRepository<File> repository ,IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<FileViewModel> CreateAsync(FileCreateModel file)
    {
        var createFolder = await repository.InsertAsync(mapper.Map<File>(file));
        await repository.SaveAsync();

        return mapper.Map<FileViewModel>(createFolder);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existFile = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "File not found");

        await repository.DeleteAsync(existFile);
        await repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<FileViewModel>> GetAllAsync()
    {
        var files = await repository.SelectAsQueryable().ToListAsync();
        return mapper.Map<IEnumerable<FileViewModel>>(files);
    }

    public async Task<FileViewModel> GetByIdAsync(long id)
    {
        var existFile = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "File not found");

        return mapper.Map<FileViewModel>(existFile);
    }

    public async Task<FileViewModel> UpdateAsync(long id, FileUpdateModel file)
    {
        var existFile = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "File not found");

        var mappedFile = mapper.Map(file,existFile);
        var updateFile = await repository.UpdateAsync(mappedFile);

        return mapper.Map<FileViewModel>(updateFile);
    }
}
