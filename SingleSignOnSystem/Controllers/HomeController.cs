using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SingleSignOnSystem.Models;

namespace SingleSignOnSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemberService _memberService;
        public HomeController(ILogger<HomeController> logger,IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            var m = _memberService.GetMember("jiang");
            ViewBag.UserName = m.UserName;
            return View();
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
