using CodeHub.Api.Models;
using CodeHub.Model.GitIgnores;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GitIgnoresController : ControllerBase
{
    private readonly IGitIgnoreService gitIgnoreService;

    public GitIgnoresController(IGitIgnoreService gitIgnoreService)
    {
        this.gitIgnoreService = gitIgnoreService;
    }

    // GET: api/<GitIgnoresController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await gitIgnoreService.GetAllAsync()
        });
    }

    // GET api/<GitIgnoresController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await gitIgnoreService.GetByIdAsync(id)
        });
    }

    // POST api/<GitIgnoresController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] GitIgnoreCreateModel gitIgnore)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await gitIgnoreService.CreateAsync(gitIgnore)
        });
    }

    // PUT api/<GitIgnoresController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] GitIgnoreUpdateModel gitIgnore)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await gitIgnoreService.UpdateAsync(id, gitIgnore)
        });
    }

    // DELETE api/<GitIgnoresController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await gitIgnoreService.DeleteAsync(id)
        });
    }
}
