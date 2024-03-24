using CodeHub.Api.Models;
using CodeHub.Model.Repositories;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RepositoriesController : ControllerBase
{
    private readonly IRepositoryService repositoryService;

    public RepositoriesController(IRepositoryService repositoryService)
    {
        this.repositoryService = repositoryService;
    }

    // GET: api/<RepositoriesController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await repositoryService.GetAllAsync()
        });
    }

    // GET api/<RepositoriesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await repositoryService.GetByIdAsync(id)
        });
    }

    // POST api/<RepositoriesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RepositoryCreateModel repository)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await repositoryService.CreateAsync(repository)
        });
    }

    // PUT api/<RepositoriesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] RepositoryUpdateModel repository)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await repositoryService.UpdateAsync(id, repository)
        });
    }

    // DELETE api/<RepositoriesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await repositoryService.DeleteAsync(id)
        });
    }
}
