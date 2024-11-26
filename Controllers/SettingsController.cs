using Microsoft.AspNetCore.Mvc;
using StateMvc.Models;

namespace StateMvc.Controllers
{
    public class SettingsController : Controller
    {

        
        [Route("Update")]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(UpdateVM updateVm)
        {
            return Content("Hello World");
        }
    }
}
//new UpdateVM{ Email="skolan@mail.se", CompanyName="Skolan"}