using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LanzhouBeefNoodles.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private INoodleRepository _noodleRepository;
        public HomeController(INoodleRepository noodleRepository)
        {
            _noodleRepository = noodleRepository;
        }
        //[Route("[action]")]
        public IActionResult Index()
        {
            var noodles = _noodleRepository.GetAllNoodles();
            return View(noodles);
        }

        //[Route("[action]")]
        public String About()
        {
            return "Hello From About";
        }
    }
}
