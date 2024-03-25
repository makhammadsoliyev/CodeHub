using CodeHub.Api.Models;
using CodeHub.Model.IssueAssignments;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IssueAssignmentsController : ControllerBase
{
    private readonly IIssueAssignmentService issueAssignmentService;

    public IssueAssignmentsController(IIssueAssignmentService issueAssignmentService)
    {
        this.issueAssignmentService = issueAssignmentService;
    }

    // GET: api/<IssueAssignmentsController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await issueAssignmentService.GetAllAsync()
        });
    }

    // GET api/<IssueAssignmentsController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await issueAssignmentService.GetByIdAsync(id)
        });
    }

    // POST api/<IssueAssignmentsController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] IssueAssignmentCreateModel issueAssignment)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await issueAssignmentService.CreateAsync(issueAssignment)
        });
    }

    // PUT api/<IssueAssignmentsController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] IssueAssignmentUpdateModel issueAssignment)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await issueAssignmentService.UpdateAsync(id, issueAssignment)
        });
    }

    // DELETE api/<IssueAssignmentsController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await issueAssignmentService.DeleteAsync(id)
        });
    }
}