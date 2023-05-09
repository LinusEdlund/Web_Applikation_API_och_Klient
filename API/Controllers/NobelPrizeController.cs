using DataManagerLibrary.Data;
using DataManagerLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class NobelPrizeController : ControllerBase
{
    private readonly INobelPrizeData _data;

    public NobelPrizeController(INobelPrizeData data)
    {
        _data = data;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
		try
		{
			return Ok(await _data.GetAll());
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
    }
}
