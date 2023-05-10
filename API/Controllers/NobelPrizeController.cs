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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
		try
		{
			var results = await _data.GetById(id);
			if (results is null)
			{
				return NotFound();
			}

			return Ok(results);
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
    }

	[HttpPost]
	public async Task<IActionResult> Create(NobelPrizeModel model)
	{
		try
		{
			await _data.Insert(model);
			return Ok();
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
	}

	[HttpPut]
	public async Task<IActionResult> Update(NobelPrizeModel model)
	{
		try
		{
			await _data.Update(model);
			return Ok();
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
	}

	[HttpDelete]
	public async Task<IActionResult> Delete(int id)
	{
		try
		{
			await _data.DeleteById(id);
			return Ok();
		}
		catch (Exception ex)
		{
			return Problem(ex.Message);
		}
	}
}
