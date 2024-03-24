using CodeHub.Api.Models;
using CodeHub.Model.Readmes;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReadmesController : ControllerBase
{
    private readonly IReadmeService readmeService;

    public ReadmesController(IReadmeService readmeService)
    {
        this.readmeService = readmeService;
    }

    // GET: api/<ReadmesController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await readmeService.GetAllAsync()
        });
    }

    // GET api/<ReadmesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await readmeService.GetByIdAsync(id)
        });
    }

    // POST api/<ReadmesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ReadmeCreateModel readme)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await readmeService.CreateAsync(readme)
        });
    }

    // PUT api/<ReadmesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] ReadmeUpdateModel readme)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await readmeService.UpdateAsync(id, readme)
        });
    }

    // DELETE api/<ReadmesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await readmeService.DeleteAsync(id)
        });
    }
}