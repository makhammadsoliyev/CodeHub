using CodeHub.Api.Models;
using CodeHub.Model.Files;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly IFileService fileService;

    public FilesController(IFileService fileService)
    {
        this.fileService = fileService;
    }

    // GET: api/<FilesController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await fileService.GetAllAsync()
        });

    }

    // GET: api/<FilesController/Details/5>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await fileService.GetByIdAsync(id)
        }); ;
    }

    // POST api/<FilesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] FileCreateModel file)
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await fileService.CreateAsync(file)
        });
    }

    // PUT api/<FilesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] FileUpdateModel file)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await fileService.UpdateAsync(id, file)
        });
    }

    // DELETE api/<FilesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await fileService.DeleteAsync(id)
        });
    }
}
