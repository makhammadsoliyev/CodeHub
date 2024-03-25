using AutoMapper;
using CodeHub.DataAccess.Repositories;
using CodeHub.Domain.Entities;
using CodeHub.Model.Licenses;
using CodeHub.Service.Exceptions;
using CodeHub.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.Service.Services;

public class LicenseService : ILicenseService
{
    private readonly IMapper mapper;
    private readonly IGenericRepository<License> repository;

    public LicenseService(IMapper mapper, IGenericRepository<License> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<LicenseViewModel> CreateAsync(LicenseCreateModell license)
    {
        var existLicense = repository.SelectAsQueryable().FirstOrDefault(l => l.Name.ToLower() == license.Name.ToLower());

        if (existLicense is not null)
            throw new CustomException(409, "License file is already exist");

        var createdLicense = await repository.InsertAsync(mapper.Map<License>(license));
        await repository.SaveAsync();

        return mapper.Map<LicenseViewModel>(createdLicense);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existLicense = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "License file is not found");

        await repository.DeleteAsync(existLicense);
        await repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<LicenseViewModel>> GetAllAsync()
    {
        var licenses = await repository.SelectAsQueryable().ToListAsync();
        return mapper.Map<IEnumerable<LicenseViewModel>>(licenses);
    }

    public async Task<LicenseViewModel> GetByIdAsync(long id)
    {
        var existLicense = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "License file is not found");

        return mapper.Map<LicenseViewModel>(existLicense);
    }

    public async Task<LicenseViewModel> UpdateAsync(long id, LicenseUpdateModel license)
    {
        var existLicense = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "License file is not found");

        var mappedLicense = mapper.Map(license, existLicense);
        var updateLicense = await repository.UpdateAsync(mappedLicense);
        await repository.SaveAsync();

        return mapper.Map<LicenseViewModel>(updateLicense);
    }
}
