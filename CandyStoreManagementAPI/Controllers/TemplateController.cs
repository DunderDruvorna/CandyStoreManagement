using CandyStoreManagementAPI.Services.Interfaces;
using CandyStoreManagementAPI.Services.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace CandyStoreManagementAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TemplateController : ControllerBase
{
    readonly ITemplateRepository _repository;

    public TemplateController(IRepositoryWrapper repository)
    {
        _repository = repository.TemplateData;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _repository.Get());
        }
        catch (Exception error)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, error.Message);
        }
    }
}