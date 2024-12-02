using Microsoft.AspNetCore.Mvc;
using StateMvc.Services;
using StateMvc.Views.Settings;

namespace StateMvc.Controllers;

public class SettingsController(DataService dataService, StateService stateService) : Controller
{
    [HttpGet("/Update")]
    [HttpGet("/")]
    public IActionResult Update()
    {
        var model = new UpdateVM();
        return View(model);
    }

    [HttpPost("/Update")]
    public IActionResult Update(UpdateVM model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        dataService.Update(model);
        dataService.


        TempDataSuccessMessage["SuccessMessage"] = "Settings updated successfully!";
        return RedirectToAction("Index");
    }

    [HttpGet("/Index")]
    public IActionResult Index()
    {
        var model = dataService.Get();
        ViewBag.SuccessMessage = TempData["SuccessMessage"]; // Lägg till meddelandet om det finns
        return View(model);
    }
}
