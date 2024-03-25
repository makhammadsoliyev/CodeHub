using CodeHub.Api.Models;
using CodeHub.Model.Follow;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FollowController:ControllerBase
{
    private IFollowService followService;

    public FollowController(IFollowService followService)
    {
        this.followService = followService;
    }

    // GET: api/<FollowController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await followService.GetAllAsync()
        });
    }

    // GET api/<FollowController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await followService.GetByIdAsync(id)
        });
    }

    // POST api/<FollowController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] FollowCreateModel follow)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await followService.CreateAsync(follow)
        });
    }

    // DELETE api/<FollowController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await followService.DeleteAsync(id)
        });
    }
}
