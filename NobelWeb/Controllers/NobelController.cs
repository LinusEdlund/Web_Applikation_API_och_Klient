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
    public async Task<IActionResult> Create(NobelPrizeModel person)
    {
        if (ModelState.IsValid)
        {
            await _nobelData.Create(person);
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
    public async Task<IActionResult> Edit(NobelPrizeModel person)
    {
        if (ModelState.IsValid)
        {
            await _nobelData.Update(person);
            return RedirectToAction("Index");
        }
        return View();
    }

    public async Task<IActionResult> Delete(int id)
    {
        var nobelPrize = await _nobelData.GetById(id);
        if (nobelPrize is null)
        {
            return NotFound();
        }
        return View(nobelPrize);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int id)
    {
        await _nobelData.Delete(id);
        return RedirectToAction("Index");
    }

    
}
