using Microsoft.AspNetCore.Mvc;
using StateMvc.Models;
using StateMvc.Services;

namespace StateMvc.Controllers;

public class SettingsController : Controller
{
    private readonly DataService dataService;
    public SettingsController(DataService dataService)
    {
        this.dataService = dataService;
    }

    [HttpGet("/Update")]
    public ActionResult Update()
    {
        var model = new UpdateVM();
        return View(model);
    }

    [HttpPost("/Update")]
    public ActionResult Update(UpdateVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        dataService.Update(model);
        TempData["SuccessMessage"] = "Settings updated successfully!";
        return RedirectToAction("Index");
    }

    [HttpGet("/Index")]
    public ActionResult Index()
    {
        var model = dataService.Get();
        ViewBag.SuccessMessage = TempData["SuccessMessage"]; // Lägg till meddelandet om det finns
        return View(model);
    }
}
