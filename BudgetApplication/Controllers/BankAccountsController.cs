using BudgetApplication.Models;
using BudgetApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BudgetApplication.Controllers
{
    [Route("bankaccounts")]
    [Authorize]
    public class BankAccountsController : Controller
    {
        private readonly BankAccountTypeService _bankAccountTypeService;
        private readonly BankAccountService _bankAccountService;
        private readonly UserManager<IdentityUser> _userManager;

        public BankAccountsController(BankAccountTypeService bankAccountTypeService, BankAccountService bankAccountService, 
            UserManager<IdentityUser> userManager)
        {
            _bankAccountTypeService = bankAccountTypeService;
            _bankAccountService = bankAccountService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult BankAccounts()
        {
            var userId = _userManager.GetUserId(User);
            return View(_bankAccountService.GetUserBankAccounts(userId));
        }

        [HttpGet("edit")]
        public async Task<IActionResult> EditBankAccount(int? bankAccountId)
        {
            if (bankAccountId == null)
            {
                return NotFound();
            }

            int myBankAccountId = (int)bankAccountId;
            ViewData["BankAccountTypeId"] = new SelectList(_bankAccountTypeService.GetBankAccountTypes(), "BankAccountTypeId", "BankAccountType", _bankAccountService.GetBankAccountTypeByBankAccountId(myBankAccountId));
            return View(await _bankAccountService.GetUserBankAccountByBankAccountIdAsync(myBankAccountId));
        }

        [HttpPost("edit")]
        public IActionResult EditBankAccount(int bankAccountId, string bankAccountName, int bankAccountTypeId, decimal balance)
        {
            _bankAccountService.EditBankAccount(bankAccountId, bankAccountName, bankAccountTypeId, balance);

            return RedirectToAction(nameof(BankAccounts));
        }

        [HttpGet("modifybalance")]
        public async Task<IActionResult> ModifyBalance(int bankAccountId)
        {
            return View(await _bankAccountService.GetUserBankAccountByBankAccountIdAsync(bankAccountId));
        }

        [HttpPost("modifybalance")]
        public IActionResult ModifyBalance(int bankAccountId, decimal balance)
        {
            _bankAccountService.ModifyBalance(bankAccountId, balance);

            return RedirectToAction(nameof(BankAccounts));
        }

        [HttpGet("createbankaccount")]
        [ActionName("CreateBankAccount")]
        public IActionResult CreateBankAccount()
        {
            ViewData["BankAccountTypeId"] = new SelectList(_bankAccountTypeService.GetBankAccountTypes(), "BankAccountTypeId", "BankAccountType");
            return View();
        }

        [HttpPost("createbankaccount")]
        public IActionResult CreateBankAccount(string bankAccountName, int bankAccountTypeId, decimal balance)
        {
            string userId = _userManager.GetUserId(User);

            int result = _bankAccountService.CreateBankAccount(userId, bankAccountName, bankAccountTypeId, balance);

            if (result == 0)
            {
                TempData["ErrorMessage"] = "You already have a bank account with that name, please try another";
                return RedirectToAction("CreateBankAccount");
            }

            return RedirectToAction(nameof(BankAccounts));
        }

        [HttpGet("deletebankaccount")]
        public IActionResult DeleteBankAccount(int bankAccountId)
        {
            BankAccounts userBankAccount = _bankAccountService.GetUserBankAccountByBankAccountIdAsync(bankAccountId).Result;
            ViewData["BankAccountTypeId"] = new SelectList(_bankAccountTypeService.GetBankAccountTypes(), "BankAccountTypeId", "BankAccountType");
            return View(userBankAccount);
        }

        [HttpPost("deletebankaccount")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBankAccount(int bankAccountId, string userId)
        {
            string currentUserId = _userManager.GetUserId(User);

            if (currentUserId != userId)
            {
                return NotFound();
            }

            int result = _bankAccountService.DeleteBankAccount(bankAccountId);

            if (result == 0)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(BankAccounts));
        }

        #region "BankAccountTypeMethods"

        [HttpGet("bankaccounttypes")]
        public async Task<IActionResult> BankAccountTypes()
        {
            return View(await _bankAccountTypeService.GetBankAccountTypesAsync());
        }

        [HttpGet("bankaccounttypes/create")]
        public IActionResult CreateBankAccountTypes()
        {
            return View();
        }

        [HttpPost("bankaccounttypes/create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBankAccountTypes([Bind("BankAccountType")] BankAccountTypes type)
        {
            if (type.BankAccountType == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(BankAccountTypes));
        }

        #endregion
    }
}
