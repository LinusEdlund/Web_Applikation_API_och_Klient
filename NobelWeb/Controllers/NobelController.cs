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

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(NobelPrizeModel person)
    {
        if (ModelState.IsValid)
        {
            _nobelData.Insert(person);
            return RedirectToAction("Index");
        }
        return View();
    }
}
