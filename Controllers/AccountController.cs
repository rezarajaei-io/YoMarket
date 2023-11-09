using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoMarket.Models;

namespace YoMarket.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountingViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            return View();
        }
    }
}

