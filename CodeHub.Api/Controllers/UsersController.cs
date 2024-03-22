using CodeHub.Api.Models;
using CodeHub.Model.Users;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService userService;

    public UsersController(IUserService userService)
    {
        this.userService = userService;
    }

    // GET: api/<UsersController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.GetAllAsync()
        });
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.GetByIdAsync(id)
        });
    }

    // POST api/<UsersController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserCreateModel user)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.CreateAsync(user)
        });
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] UserUpdateModel user)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.UpdateAsync(id, user)
        });
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.DeleteAsync(id)
        });
    }
}
