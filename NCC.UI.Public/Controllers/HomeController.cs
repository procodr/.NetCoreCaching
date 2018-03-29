using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCC.Services.Contract;

namespace NCC.UI.Public.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;
        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            ViewBag.Status = _personService.GetStatus();
            return View(_personService.GetPersons());
        }
    }
}