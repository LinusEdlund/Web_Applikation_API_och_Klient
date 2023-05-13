using DataManagerLibrary.Data;
using DataManagerLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace NobelWeb.Controllers;
public class NobelController : Controller
{
    private readonly INobelPrizeData _nobelData;

    public NobelController(INobelPrizeData nobelData)
    {
        _nobelData = nobelData;
    }

    public async Task<IActionResult> Index()
    {
        var nobelList = await _nobelData.GetAll();
        return View(nobelList.ToList());
    }
}
