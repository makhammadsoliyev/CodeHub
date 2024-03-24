using CodeHub.Api.Models;
using CodeHub.Model.Folders;
using CodeHub.Service.Interfaces;
using CodeHub.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeHub.Api.Controllers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

[Route("api/[controller]")]
[ApiController]

public class FoldersController : ControllerBase
{
    private readonly IFolderService folderService;


    public FoldersController(IFolderService folderService)
    {
        this.folderService = folderService;
    }

    
    // GET: api/<FoldersController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await folderService.GetAllAsync()
        });
    }

    
    // GET: api/<FoldersController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await folderService.GetByIdAsync(id)
        });
    }

    
    // POST api/<FoldersController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] FolderCreateModel folder)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await folderService.CreateAsync(folder)
        });
    }

    
    // PUT api/<FoldersController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutASync(long id, [FromBody] FolderUpdateModel folder)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await folderService.UpdateAsync(id, folder)
        });
    }

    
    // DELETE api/<FoldersController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await folderService.DeleteAsync(id)
        });
    }
}
