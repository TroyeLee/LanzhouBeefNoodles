using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LanzhouBeefNoodles.Controllers
{
    public class NoodleController : Controller
    {
        public IList<String> List()
        {
            return new List<String>() { "牛肉面","羊肉面","鸡蛋面"};
        }
    }
}
