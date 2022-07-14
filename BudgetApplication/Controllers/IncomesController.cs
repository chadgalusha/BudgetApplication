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
        public async Task<IActionResult> Incomes()
        {
            var userId = _userManager.GetUserId(User);
            ViewData["IncomeTypesId"] = new SelectList(await _incomeTypeService.GetAllAsync(), "IncomeTypesId", "IncomeTypes");
            ViewData["PaymentFrequencyTypesId"] = new SelectList(await _paymentFrequencyTypesService.GetAllAsync(), "PaymentFrequencyTypeId", "PaymentFrequencyType");
            return View(await _incomeService.GetUserIncomesAsync(userId));
        }

        // IMPLEMENT VIEW!!
    }
}
