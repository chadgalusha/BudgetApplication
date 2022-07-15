using BudgetApplication.Models;
using BudgetApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetApplication.Controllers
{
    [Route("incomes")]
    [Authorize]
    public class IncomesController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly ITypeService<PaymentFrequencyTypes> _paymentFrequencyTypesService;
        private readonly ITypeService<IncomeTypes> _incomeTypeService;
        private readonly UserManager<IdentityUser> _userManager;

        public IncomesController(IIncomeService incomeService, ITypeService<PaymentFrequencyTypes> paymentFrequencyTypesService,
            ITypeService<IncomeTypes> incomeTypesService, UserManager<IdentityUser> userManager)
        {
            _incomeService = incomeService;
            _paymentFrequencyTypesService = paymentFrequencyTypesService;
            _incomeTypeService = incomeTypesService;
            _userManager = userManager;
        } 

        [HttpGet]
        public IActionResult Incomes()
        {
            var userId = _userManager.GetUserId(User);
            return View(_incomeService.GetListIncomes(userId));
        }

        [HttpGet("createincome")]
        [ActionName("CreateIncome")]
        public async Task<IActionResult> CreateIncome()
        {
            ViewData["IncomeTypeId"] = new SelectList(await _incomeTypeService.GetAllAsync(), "IncomeTypeId", "IncomeType");
            ViewData["PaymentFrequencyTypeId"] = new SelectList(await _paymentFrequencyTypesService.GetAllAsync(), "PaymentFrequencyTypeId", "PaymentFrequencyType");
            return View();
        }

        [HttpPost("createincome")]
        public async Task<IActionResult> CreateIncome(string incomeName, int incomeTypeId, int paymentFrequencyTypeId)
        {
            string userId = _userManager.GetUserId(User);

            int result = await _incomeService.CreateIncomeAsync(incomeName, userId, incomeTypeId, paymentFrequencyTypeId);

            if (result == 0)
            {
                TempData["ErrorMessage"] = "You already have an income with that name, please try another";
                return RedirectToAction("CreateIncome");
            }

            if (result == -1)
            {
                TempData["ErrorMessage"] = "Error creating income, please try again";
                return RedirectToAction("CreateIncome");
            }

            return RedirectToAction(nameof(Incomes));
        }

    }
}
