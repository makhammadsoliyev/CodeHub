using CodeHub.Api.Models;
using CodeHub.Model.Issues;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class IssuesController : ControllerBase
{
    private IIssueService issueService;

    public IssuesController(IIssueService issueService)
    {
        this.issueService = issueService;
    }


    // GET: api/<IssuesController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await issueService.GetAllAsync()
        });
    }


    // GET api/<IssuesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await issueService.GetByIdAsync(id)
        });
    }

    // POST api/<IssuesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] IssueCreateModel issue)
    {
        return Ok(new Response
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await issueService.CreateAsync(issue)
        });
    }

    // PUT api/<IssuesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] IssueUpdateModel issue)
    {
        return Ok(new Response
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await issueService.UpdateAsync(id, issue)
        });
    }

    // DELETE api/<IssuesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            Message = "Ok",
            StatusCode = 200,
            Data = await issueService.DeleteAsync(id)
        });
    }
}