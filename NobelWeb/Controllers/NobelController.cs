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
            _nobelData.Create(person);
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Edit(int id)
    {
        NobelPrizeModel? nobelPrize = await _nobelData.GetById(id);
        if (nobelPrize is null)
        {
            return NotFound();
        }

        return View(nobelPrize);
    }

    [HttpPost]
    public IActionResult Edit(NobelPrizeModel person)
    {
        if (ModelState.IsValid)
        {
            _nobelData.Update(person);
            return RedirectToAction("Index");
        }
        return View();
    }

    
}
