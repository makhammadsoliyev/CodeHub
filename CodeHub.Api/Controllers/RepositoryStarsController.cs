using CodeHub.Api.Models;
using CodeHub.Model.RepositoryStar;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RepositoryStarsController : ControllerBase
{
    private readonly IRepositoryStarService repositoryStarService;

    public RepositoryStarsController(IRepositoryStarService repositoryStarService)
    {
        this.repositoryStarService = repositoryStarService;
    }

    // GET: api/<RepositoryStarsController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await repositoryStarService.GetAllAsync()
        });
    }

    // GET api/<RepositoryStarsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await repositoryStarService.GetByIdAsync(id)
        });
    }

    // Post api/<RepositoryStarsController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RepositoryStarCreateModel repositoryStar)
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await repositoryStarService.CreateAsync(repositoryStar)
        });
    }

    // DELETE api/<RepositoryStarsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await repositoryStarService.DeleteAsync(id)
        });
    }
}
