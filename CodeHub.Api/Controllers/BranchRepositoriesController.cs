using CodeHub.Api.Models;
using CodeHub.Model.BranchRepositories;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BranchRepositoriesController : ControllerBase
{
    private readonly IBranchRepositoryService branchRepositoryService;

    public BranchRepositoriesController(IBranchRepositoryService branchRepositoryService)
    {
        this.branchRepositoryService = branchRepositoryService;
    }

    // GET: api/<BranchRepositoriesController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await branchRepositoryService.GetAllAsync()
        });
    }

    // GET api/<BranchRepositoriesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await branchRepositoryService.GetByIdAsync(id)
        });
    }

    // POST api/<BranchRepositoriesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] BranchRepositoryCreateModel branchRepository)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await branchRepositoryService.CreateAsync(branchRepository)
        });
    }

    // PUT api/<BranchRepositoriesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] BranchRepositoryUpdateModel branchRepository)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await branchRepositoryService.UpdateAsync(id, branchRepository)
        });
    }

    // DELETE api/<BranchRepositoriesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await branchRepositoryService.DeleteAsync(id)
        });
    }
}
