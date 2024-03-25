using CodeHub.Api.Models;
using CodeHub.Model.RepositroyForks;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RepositoryForksController : ControllerBase
{
    private readonly IRepositoryForkService repositoryForkService;
    public RepositoryForksController(IRepositoryForkService repositoryForkService)
    {
        this.repositoryForkService = repositoryForkService;
    }

    // GET: api/<RepositoryForkController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await repositoryForkService.GetAllAsync()
        });

    }

    // GET: api/<RepositoryForkController/Details/5>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await repositoryForkService.GetByIdAsync(id)
        });
    }

    // POST api/<RepositoryForkController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RepositoryForkCreateModel repositoryFork)
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await repositoryForkService.CreateAsync(repositoryFork)
        });
    }

    // DELETE api/<RepositoryForkController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await repositoryForkService.DeleteAsync(id)
        });
    }
}
