using Microsoft.AspNetCore.Mvc;
using System;

namespace LanzhouBeefNoodles.Controllers
{
    
   // public class TestController//1,类名+Controller
   //[Controller]//2，Controller属性
   //public class Test:Controller//3，继承Controller父类
   //当任何一个类符合以上三种的任意一个，ASP.Net MVC识别为Controller类，同时赋予这个类MVC最基本的一些功能
   //只有使用public关键词，http请求才能从外部访问控制器
   public class Test:Controller
    {
        public ActionResult Index()
        {
            return Content("Hello From test index");
        }

        //[Route("[action]")]
        public String About()
        {
            return "Hello From test About";
        }
        //可以通过约定的命名规范，绑定控制器和视图
        //View()函数最终会以命名约定的形式，自动匹配Controller名Test、Action函数名Contact和试图文件夹Views/Test/Contact.cshtml
        //以ActionResult的形式发送并且回复给浏览器
        public ActionResult Contact()
        {
            return View();
        }
    }
}
