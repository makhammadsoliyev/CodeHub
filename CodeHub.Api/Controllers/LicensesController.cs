using CodeHub.Api.Models;
using CodeHub.Model.Licenses;
using CodeHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LicensesController : ControllerBase
{
    private readonly ILicenseService licenseService;

    public LicensesController(ILicenseService licenseService)
    {
        this.licenseService = licenseService;
    }

    // GET: api/<LicensesController>
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await licenseService.GetAllAsync()
        });
    }

    // GET api/<LicensesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await licenseService.GetByIdAsync(id)
        });
    }

    // POST api/<LicensesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LicenseCreateModell license)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await licenseService.CreateAsync(license)
        });
    }

    // PUT api/<LicensesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(long id, [FromBody] LicenseUpdateModel license)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await licenseService.UpdateAsync(id, license)
        });
    }

    // DELETE api/<LicensesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await licenseService.DeleteAsync(id)
        });
    }
}
