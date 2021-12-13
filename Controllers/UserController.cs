using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LanzhouBeefNoodles.Controllers
{
    [Route("admin/[controller]/[action]")]
    public class UserController : Controller
    {
        public IList<String> Index()
        {
            return new List<String> { "李朝伟","朝伟","伟" };
        }
    }
}
