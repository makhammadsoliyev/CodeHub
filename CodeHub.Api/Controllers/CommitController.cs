using CodeHub.Api.Models;
using CodeHub.Model.Commits;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeHub.Api.Controllers;

public class CommitController:ControllerBase
{
    private readonly ICommitService commitService;
    public CommitController(ICommitService commitService)
    {
        this.commitService = commitService;
    }

    // GET: api/<CommitController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await commitService.GetAllAsync()
        });

    }

    // GET: api/<CommitController/Details/5>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await commitService.GetByIdAsync(id)
        });
    }

    // POST api/<CommitController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CommitCreateModel commit)
    {
        return Ok(new Response()
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await commitService.CreateAsync(commit)
        });
    }

    // DELETE api/<CommitController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await commitService.DeleteAsync(id)
        });
    }
}
