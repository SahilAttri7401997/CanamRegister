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

            if (model.Password == model.ConfirmPassword)
            {
                // Validate PST Number format
                if (!IsValidPSTNumber(model.PSTNumber))
                {
                    TempData["ErrorMessage"] = "PST Number must be in the format PST-1234567 and exactly 11 characters long.";
                    return View("Index", model);
                }

                // Validate Federal Tax ID format
                if (!IsValidTaxID(model.TaxID))
                {
                    TempData["ErrorMessage"] = "Federal Tax ID must be in the format 123456789-RT0001 and exactly 15 characters long.";
                    return View("Index", model);
                }

                var customerModel = await _registerService.SaveCustomer(model);
                if (customerModel != null)
                {
                    TempData["SuccessMessage"] = "Register successful!";
                    return RedirectToAction("Index"); // Redirect to avoid resubmission
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Password and Confirm Password are not the same!";
                return View("Index", model);
            }

            return View("Index", model);
        }

        // Method to validate PST Number
        private bool IsValidPSTNumber(string pstNumber)
        {
            return !string.IsNullOrEmpty(pstNumber) && System.Text.RegularExpressions.Regex.IsMatch(pstNumber, @"^PST-\d{7}$");
        }

        // Method to validate Federal Tax ID
        private bool IsValidTaxID(string taxID)
        {
            return !string.IsNullOrEmpty(taxID) && System.Text.RegularExpressions.Regex.IsMatch(taxID, @"^\d{9}-RT\d{4}$");
        }

    }
}
