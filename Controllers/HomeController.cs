using Microsoft.AspNetCore.Mvc;
using System;

namespace LanzhouBeefNoodles.Controllers
{
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        //[Route("[action]")]
        public String Index()
        {
            return "Hello From Home";
        }

        //[Route("[action]")]
        public String About()
        {
            return "Hello From About";
        }
    }
}
