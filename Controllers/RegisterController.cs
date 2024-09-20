using CanamRegister.Interfaces;
using CanamRegister.Models;
using Microsoft.AspNetCore.Mvc;

namespace CanamRegister.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterService _registerService;
        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCustomer(CreditAccountFormRequestModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    var customerModel = await _registerService.SaveCustomer(model);
                    if (customerModel != null)
                    {
                        TempData["SuccessMessage"] = "Register successful!";
                        return RedirectToAction("Index"); // Redirect to avoid resubmission
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Password and Confirm Password are not Same!";
                    return View("Index", model);
                }
            }
            TempData["ErrorMessage"] = "There was an error processing your request.";
            return View("Index", model);
        }
    }
}
